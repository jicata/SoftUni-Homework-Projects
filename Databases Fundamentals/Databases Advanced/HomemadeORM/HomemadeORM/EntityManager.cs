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
            return true;

        }

        private bool Update<T>(T entity, FieldInfo primaryKey)
        {
            string updateSqlStatement = this.PrepareUpdateSqlStatement(entity, primaryKey);
        }

        private string PrepareUpdateSqlStatement<T>(T entity, FieldInfo primaryKey)
        {
            "UPDATE"
        }

        public  bool Insert<T>(T entity, FieldInfo primaryKey)
        {
            string insertSqlStatement = this.PrepareInsertSqlStatement(entity, primaryKey);
            int rowsAffected = 0;
            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                con.Open();
                SqlCommand insertCommand = new SqlCommand(insertSqlStatement);
                rowsAffected = insertCommand.ExecuteNonQuery();
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
                if (fieldInfo.FieldType.Name.ToLower() == "string" || fieldInfo.FieldType.Name.ToLower() == "datetime")
                {
                    valuesBuilder.Append($@"'{fieldInfo.GetValue(entity)}', ");
                }
                else
                {
                    valuesBuilder.Append(fieldInfo.GetValue(entity) +", ");
                }
            }
            valuesBuilder.Remove(valuesBuilder.Length - 2, 2);

            string insertQuery = $@"INSERT INTO {GetTableName(entity.GetType())} ({string.Join(", ", columnNames)}) VALUES " +
                                 $@"({valuesBuilder})";
            //TODO: test
            string retrieveIdForEntityQuery = $@"SELECT MAX({primaryKey.Name}) FROM {GetTableName(entity.GetType())}";
            using (SqlConnection con = new SqlConnection(this.connectionString))
            {
                con.Open();
                SqlCommand retrieveIdCommand = new SqlCommand(retrieveIdForEntityQuery, con);
                int entityId = (int) retrieveIdCommand.ExecuteScalar();
                primaryKey.SetValue(entity, entityId);
            }
             return insertQuery;
        }

        public T FindById<T>(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T> FindAll<T>()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T> FindAll<T>(string where)
        {
            throw new System.NotImplementedException();
        }

        public T FindFirst<T>()
        {
            throw new System.NotImplementedException();
        }

        public T FindFirst<T>(string where)
        {
            throw new System.NotImplementedException();
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
            string checkIfTableExistsQuery = $@"IF OBJECT_ID(N'dbo.{entity.Name}', N'U') IS NOT NULL " +
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
                createTableQuery.AppendLine($@"{columnNames[i]} {this.ToDbType(fieldInfo[i])}, ");
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

        private string ToDbType(FieldInfo fieldInfo)
        {
            switch (fieldInfo.FieldType.Name.ToLower())
            {
                case "int32":
                    return "INT";
                case "bool":
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
