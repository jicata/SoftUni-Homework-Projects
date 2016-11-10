namespace _02.CreateUser.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<UserContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UserContext context)
        {
            
            SeedUsers(context);
        }

        private void SeedUsers(UserContext context)
        {
            List<User> users = new List<User>()
            {
                new User()
                {
                    Username = "Pesho",
                    Password = "Kur1234^",
                    Age = 20,
                    Email = "pesho@kalofer.bg",
                    LastTimeLoggedIn = new DateTime(2016,10,09)
                },
                new User()
                {
                    Username = "Gosho",
                    Password = "Kur1234^^",
                    Age = 37,
                    Email = "gosgo@mursha.bg",
                    LastTimeLoggedIn = new DateTime(2006, 06, 04)
                },
                new User()
                {
                    Username = "JIcata",
                    Password = "EbAsiP@ssAbr1t",
                    Age = 18,
                    Email = "jitza@test.bg",
                    LastTimeLoggedIn = new DateTime(2016, 09, 23)
                },
                new User()
                {
                    Username = "Munio",
                    Password = "Sw@gst1k",
                    Age = 49,
                    Email = "kaluf@kalufchev.kur",
                    LastTimeLoggedIn = new DateTime(2014, 10, 11)
                }
            };
            foreach (var user in users)
            {
                context.Users.Add(user);
            }
            context.SaveChanges();
        }
    }
}
