namespace HomemadeORM
{
    using System.Data.SqlClient;

    public class ConnectionStringBuilder
    {
        private SqlConnectionStringBuilder builder;
        private string connectionString;

        public ConnectionStringBuilder(string databaseName)
        {
            this.builder = new SqlConnectionStringBuilder();
            this.builder["Data Source"] = "6pekIV\\SQLEXPRESS";
            this.builder["Integrated Security"] = true;
            this.builder["Connect Timeout"] = 1000;
            this.builder["Trusted_Connection"] = true;
            this.builder["Initial Catalog"] = databaseName;
            this.connectionString = this.builder.ToString();
        }

        public string ConnectionString
        {
            get
            {
                return connectionString;
            }
        }
    }
}
