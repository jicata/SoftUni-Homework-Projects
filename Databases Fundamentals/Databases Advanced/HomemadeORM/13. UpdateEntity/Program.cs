namespace _13.UpdateEntity
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using HomemadeORM;
    using _12.AddNewEntityAndTrim;

    class Program
    {
        static void Main()
        {
            ConnectionStringBuilder builder = new ConnectionStringBuilder("Test2");
            string connectionString = builder.ConnectionString;

            EntityManager manager = new EntityManager(connectionString, true);
            Book book1 = new Book("TheBible", "God", DateTime.Parse("0330-11-05 16:20:20"), "Ancient Greek", true, 10);
            Book book2 = new Book("MeinKampf", "Chicho Adi", DateTime.Parse("1925-07-18 10:00:00"), "German", false, 7);
            Book book3 = new Book(@"Hitchhikers Guide To The Galaxy", "Douglas Adams", DateTime.Parse("1995-04-20 13:38:00"), "English", true, 8);
            manager.Persist(book1);
            manager.Persist(book2);
            manager.Persist(book3);
            string retrieveLatestTopBooksQuery =  @"SELECT TOP 3 b.Title,
                                                                 b.Author,
			                                                     b.Rating
                                                    FROM Books AS b
                                                    ORDER BY b.PublishedOn DESC, b.Rating DESC, b.Title";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand retrieveCommand = new SqlCommand(retrieveLatestTopBooksQuery, conn);
                using (SqlDataReader reader = retrieveCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0]} ({reader[1]}) - {reader[2]}/10");
                    }
                }
            }

        }

    }
}
