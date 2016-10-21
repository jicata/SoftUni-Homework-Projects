namespace HomemadeORM
{
    using System;
    using System.Reflection;
    using Attributes;
    using Entities;

    class Program
    {
        static void Main()
        {
            User user = new User("kur","kur123", 50, DateTime.Now);

            EntityManager manager = new EntityManager("asd", true);
            FieldInfo primaryKey = manager.GetId(user.GetType());
            object primaryKeyValue = primaryKey.GetValue(user);
            manager.Insert(user, primaryKey);

        }
    }
}
