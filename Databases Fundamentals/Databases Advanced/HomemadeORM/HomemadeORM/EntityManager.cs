namespace HomemadeORM
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using Attributes;
    using Contracts;
    public class EntityManager : IDbContext
    {

        private SqlConnection connection;
        private string connectionString;
        private bool isCodeFirst;

        public EntityManager(string connectionString, bool isCodeFirst)
        {
            this.connectionString = connectionString;
            this.isCodeFirst = isCodeFirst;
        }

        public bool Persist(object entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity cannot be null");
            }
            if (this.isCodeFirst && !this.CheckIfTableExists(entity.GetType()))
            {
                this.CreateTable(entity.GetType());
            }

            FieldInfo primaryKey = GetId(entity.GetType());
            object primaryKeyValue = primaryKey.GetValue(entity);
         
            if (primaryKeyValue == null || (int) primaryKeyValue <= 0)
            {
                return this.Insert(entity, primaryKey);
            }
            return this.Update(entity, primaryKey);


        }

        private bool Update<T>(T entity, FieldInfo primaryKey)
        {
            string updateSqlStatement = this.PrepareUpdateSqlStatement(entity, primaryKey);
            int rowsAffected = 0;
            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                con.Open();
                SqlCommand updateCommand = new SqlCommand(updateSqlStatement, con);
                rowsAffected = updateCommand.ExecuteNonQuery();
            }
            return rowsAffected > 0;
        }

        private string PrepareUpdateSqlStatement<T>(T entity, FieldInfo primaryKey)
        {
            StringBuilder query = new StringBuilder();
            FieldInfo[] fields = GetFieldInfoForEntity(entity.GetType());
            string tableName = this.GetTableName(entity.GetType());
            query.AppendLine($@"UPDATE {tableName} ");
            query.Append(@"SET ");
            foreach (var field in fields)
            {
                string sqlString = CreateSqlString(entity, field);
                query.Append($@"{this.GetFieldName(field)}={sqlString}, ");
            }
            query.Remove(query.Length - 2, 2);
            query.AppendLine();
            query.Append($@"WHERE {this.GetId(entity.GetType()).Name} = {primaryKey.GetValue(entity)}");
            return query.ToString();
        }

        private  bool Insert<T>(T entity, FieldInfo primaryKey)
        {
            string insertSqlStatement = this.PrepareInsertSqlStatement(entity, primaryKey);
            int rowsAffected = 0;
            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                con.Open();
                SqlCommand insertCommand = new SqlCommand(insertSqlStatement, con);
                rowsAffected = insertCommand.ExecuteNonQuery();
            }
            string retrieveIdForEntityQuery = $@"SELECT MAX(Id) AS LastId FROM {GetTableName(entity.GetType())} AS l";
            //Console.WriteLine(retrieveIdForEntityQuery);
            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                con.Open();
                SqlCommand retrieveIdCommand = new SqlCommand(retrieveIdForEntityQuery, con);

                int entityId = int.Parse(retrieveIdCommand.ExecuteScalar().ToString());
                primaryKey.SetValue(entity, entityId);
            }
            return rowsAffected > 0;
        }

        private string PrepareInsertSqlStatement<T>(T entity, FieldInfo primaryKey)
        {
            var columnNames = GetColumnNamesForEntity(entity.GetType());

            var values = GetFieldInfoForEntity(entity.GetType());

            StringBuilder valuesBuilder = new StringBuilder();
            foreach (var fieldInfo in values)
            {
                var sqlString = CreateSqlString(entity, fieldInfo);
                valuesBuilder.Append($"{sqlString}, ");
            }
            valuesBuilder.Remove(valuesBuilder.Length - 2, 2);

            string insertQuery = $@"INSERT INTO {GetTableName(entity.GetType())} ({string.Join(", ", columnNames)}) VALUES " +
                                 $@"({valuesBuilder})";
             return insertQuery;
        }

        private static string CreateSqlString<T>(T entity, FieldInfo fieldInfo)
        {
            string sqlString = string.Empty;
            if (fieldInfo.FieldType.Name.ToLower() == "string" || fieldInfo.FieldType.Name.ToLower() == "datetime")
            {
                sqlString = $@"'{fieldInfo.GetValue(entity)}'";
            }
            else if (fieldInfo.FieldType.Name.ToLower() == "boolean")
            {
                int boolean = (bool)fieldInfo.GetValue(entity) ? 1 : 0;
                sqlString = boolean.ToString();
            }
            else
            {
                sqlString = $@"{fieldInfo.GetValue(entity)}";
            }
            return sqlString;
        }

        public T FindById<T>(int id)
        {
            T result = default(T);
            string getEntityByIdQuery = $@"SELECT * FROM {this.GetTableName(typeof(T))} WHERE Id = @Id";
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                SqlCommand getByIdCommand = new SqlCommand(getEntityByIdQuery, conn);
                getByIdCommand.Parameters.AddWithValue("@Id", id);
                using (SqlDataReader reader = getByIdCommand.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        throw new ArgumentException($"Entity with Id {id} not found");
                    }
                    reader.Read();
                    result = this.CreateEntity<T>(reader);
                }
            }
            return result;
        }

        private T CreateEntity<T>(SqlDataReader reader)
        {
            object[] values = new object[reader.FieldCount];
            reader.GetValues(values);
            
            Type[] types = new Type[values.Length-1];
            for (int i = 1; i < values.Length; i++)
            {
                types[i - 1] = values[i].GetType();
            }

            T entity = (T) (typeof(T)).GetConstructor(types).Invoke(values.Skip(1).ToArray());
            typeof(T).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                     .FirstOrDefault(x=>x.IsDefined(typeof(IdAttribute)))
                     .SetValue(entity, values[0]);


            return entity;
        }

        public IEnumerable<T> FindAll<T>()
        {
            List<T> entities = new List<T>();
            string getAllEntities = $@"SELECT * FROM {this.GetTableName(typeof(T))}";
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                SqlCommand getAllCommand = new SqlCommand(getAllEntities, conn);
                using (SqlDataReader reader = getAllCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        entities.Add(CreateEntity<T>(reader));
                    }
                }
            }
            return entities;
        }

        public IEnumerable<T> FindAll<T>(string where)
        {
            List<T> entities = new List<T>();
            string getAllEntities = $@"SELECT * FROM {this.GetTableName(typeof(T))} {where}";
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                SqlCommand getAllCommand = new SqlCommand(getAllEntities, conn);
                using (SqlDataReader reader = getAllCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        entities.Add(CreateEntity<T>(reader));
                    }
                }
            }
            return entities;
        }

        public T FindFirst<T>()
        {
            T result = default(T);
            string getEntityByIdQuery = $@"SELECT TOP 1 * FROM {this.GetTableName(typeof(T))}";
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                SqlCommand getByIdCommand = new SqlCommand(getEntityByIdQuery, conn);
                using (SqlDataReader reader = getByIdCommand.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        throw new ArgumentException($"Table is empty");
                    }
                    reader.Read();
                    result = this.CreateEntity<T>(reader);
                }
            }
            return result;
        }

        public T FindFirst<T>(string where)
        {
            T result = default(T);
            string getEntityByIdQuery = $@"SELECT TOP 1 * FROM {this.GetTableName(typeof(T))} {where}";
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            {
                conn.Open();
                SqlCommand getByIdCommand = new SqlCommand(getEntityByIdQuery, conn);
                using (SqlDataReader reader = getByIdCommand.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        throw new ArgumentException($"Table is empty");
                    }
                    reader.Read();
                    result = this.CreateEntity<T>(reader);
                }
            }
            return result;
        }

        public FieldInfo GetId(Type entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity is null");
            }

            var field = entity.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                       .FirstOrDefault(x=>x.IsDefined(typeof(IdAttribute)));
            if (field == null)
            {
                throw new InvalidOperationException("Cannot operate on entity without ID");
            }
            return field;
        }

        public string GetTableName(Type entity)
        {
            string result = string.Empty;
            if (entity == null)
            {
                throw new ArgumentNullException("Entity is null");
            }
            if (entity.IsDefined(typeof(EntityAttribute)))
            {
                result = entity.GetCustomAttribute<EntityAttribute>(false).TableName;
            }
            else
            {
                result = entity.Name;
            }
            return result;
        }

        private string GetFieldName(FieldInfo field)
        {
            string result = string.Empty;
            if (field == null)
            {
                throw new ArgumentNullException("Field is null");
            }
            if (field.IsDefined(typeof(ColumnAttribute)))
            {
                result = field.GetCustomAttribute<ColumnAttribute>(false).Name;
            }
            else
            {
                result = field.Name;
            }
            return result;
        }

        private bool CheckIfTableExists(Type entity)
        {
            int result = 0;
            string checkIfTableExistsQuery = $@"IF OBJECT_ID(N'dbo.{GetTableName(entity)}', N'U') IS NOT NULL " +
                                             "BEGIN " +
                                                "SELECT 1 " +
                                             "END " +
                                             "ELSE " +
                                             "BEGIN " +
                                                "SELECT 0 " +
                                             "END ";

            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                con.Open();
                SqlCommand checkCommand = new SqlCommand(checkIfTableExistsQuery, con);
                result = (int)checkCommand.ExecuteScalar();
            }
            return result > 0;
        }

        public void CreateTable(Type entity)
        {
            StringBuilder createTableQuery = new StringBuilder();
            createTableQuery.AppendLine($@"CREATE TABLE {this.GetTableName(entity)} ");
            createTableQuery.AppendLine("(");
            createTableQuery.AppendLine("Id INT IDENTITY (1,1) PRIMARY KEY, ");


            string[] columnNames = this.GetColumnNamesForEntity(entity);

            FieldInfo[] fieldInfo = this.GetFieldInfoForEntity(entity);

            for (int i = 0; i < fieldInfo.Length; i++)
            {
                createTableQuery.AppendLine($@"{columnNames[i]} {this.ConvertToDbDataType(fieldInfo[i])}, ");
            }

            createTableQuery.Remove(createTableQuery.Length - 4, 2);
            createTableQuery.Append(")");

            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                con.Open();
                SqlCommand createTableCommand = new SqlCommand(createTableQuery.ToString(),con);
                    createTableCommand.ExecuteNonQuery();
            }
        }

        private string ConvertToDbDataType(FieldInfo fieldInfo)
        {
            switch (fieldInfo.FieldType.Name.ToLower())
            {
                case "int32":
                    return "INT";
                case "boolean":
                    return "BIT";
                case "string":
                    return "VARCHAR(100)";
                case "datetime":
                    return "DATETIME";
                default:
                    Console.WriteLine(fieldInfo.FieldType.Name.ToLower());
                    throw new InvalidCastException("UnrecognizedType");
            }
        }

        private FieldInfo[] GetFieldInfoForEntity(Type entity)
        {
            FieldInfo[] values =
                entity.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                    .Where(x => x.IsDefined(typeof(ColumnAttribute))).ToArray();
            return values;
        }

        private string[] GetColumnNamesForEntity(Type entity)
        {
            string[] columnNames =
                entity.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                    .Where(x => x.IsDefined(typeof(ColumnAttribute)))
                    .Select(x => x.GetCustomAttribute<ColumnAttribute>(false).Name)
                    .ToArray();
            return columnNames;
        }

    }
}
