namespace _14.UpdateRecords
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
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

            int year = int.Parse(Console.ReadLine());
            RetrieveAndUpdateAfterYear(year, manager, connectionString);

        }

        public static void RetrieveAndUpdateAfterYear(int year, EntityManager manager, string connectionString)
        {

            List<Book> books = manager.FindAll<Book>($"WHERE DATEPART(year,PublishedOn) > {year} AND IsHardCovered = 1").ToList();
            foreach (var book in books)
            {
                book.Title = book.Title.ToUpper();
                manager.Persist(book);
            }
            Console.WriteLine($"Books published after {year}: {books.Count}");
            Console.WriteLine(string.Join("\n", books));


        }
    }
}

