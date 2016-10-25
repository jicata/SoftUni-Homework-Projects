namespace _11.FetchUsers
{
    using System;
    using HomemadeORM;
    using HomemadeORM.Entities;

    class Program
    {
        static void Main()
        {
            ConnectionStringBuilder builder = new ConnectionStringBuilder("Test2");
            string connectionString = builder.ConnectionString;

            EntityManager manager = new EntityManager(connectionString, true);
            var ruk = manager.FindFirst<User>("WHERE Password = 'PackOFudge'");
            Console.WriteLine(ruk);

        }
    }
}
