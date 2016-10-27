namespace HomemadeORM
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Attributes;
    using Entities;

    class Program
    {
        static void Main()
        {
            ConnectionStringBuilder builder = new ConnectionStringBuilder("Test2");
            string connectionString = builder.ConnectionString;
          
            EntityManager manager = new EntityManager(connectionString, true);
            var kur = manager.FindFirst<User>("WHERE Password = 'PackOFudge'");
            Console.WriteLine(kur);

        }
    }
}
