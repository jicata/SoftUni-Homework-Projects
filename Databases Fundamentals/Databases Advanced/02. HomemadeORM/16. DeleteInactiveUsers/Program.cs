namespace _16.DeleteInactiveUsers
{
    using System;
    using System.Collections.Generic;
    using HomemadeORM;
    using HomemadeORM.Entities;

    class Program
    {
        static void Main()
        {
            ConnectionStringBuilder builder = new ConnectionStringBuilder("Test2");
            string connectionString = builder.ConnectionString;

            List<User> users = new List<User>()
            {
                new User("Pesho", "HackerSam", 28, DateTime.Parse("2008-08-08"), true,DateTime.Now),
                new User("LizzardMan", "ssszzssz", 350, DateTime.Parse("2000-02-03"), true,DateTime.Parse("2010-02-01")),
                new User("MasterYi", "WujuStyle123", 67, DateTime.Parse("2014-05-13"), true,DateTime.Parse("2015-10-25")),
                new User("Kaltak123", "batal", 18, DateTime.Now,true, DateTime.Now)
            };
            
            EntityManager manager = new EntityManager(connectionString, true);
            foreach (var user in users)
            {
                manager.Persist(user);
            }

            Console.Write("Enter a username: ");
            string command = Console.ReadLine();
            while (command != "End")
            {
                try
                {
                    var user = GetUserByUserName(command, manager);
                    Console.WriteLine($"User {user.Username} was last online {CalculateRelativeTimeSinceLastLogin(user)}");
                    if (!user.IsActive)
                    {
                        Console.WriteLine("Would you like to delete that user? (yes/no)");
                        command = Console.ReadLine();
                        if (command.ToLower() == "yes")
                        {
                            int affectedRows = manager.DeleteAll<User>($"WHERE Id = {user.Id}");
                            if (affectedRows != 0)
                            {
                                Console.WriteLine($"User {user.Username} was successfully deleted from the database");
                            }
                            else
                            {
                                Console.WriteLine($"User {user.Username} was not deleted from the database");
                            }
                        }
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
                Console.Write("Enter a username: ");
                command = Console.ReadLine();
            }

        }

        public static User GetUserByUserName(string username, EntityManager manager)
        {
            User user = manager.FindFirst<User>($"WHERE Username = '{username}'");
            return user;
        }

        public static string CalculateRelativeTimeSinceLastLogin(User user)
        {
            TimeSpan span = DateTime.Now - user.LastLoginTime;
            if (span.Seconds < 1)
            {
                return "less than a second ago";
            }
            else if (span.Minutes < 1)
            {
                return "less than a minute ago";
            }
            else if (span.Hours < 1)
            {
                return $"{span.Hours/60} minutes ago";
            }
            else if (span.Days < 1)
            {
                return $"{span.Days/24} hours ago";
            }
            else if (span.Days < 30)
            {
                return $"{span.Days} days ago";
            }
            else if (span.Days < 365)
            {
                return $"{span.Days/30} months ago";
            }
            else
            {
                return "more than an year";
            }
        }
    }
}