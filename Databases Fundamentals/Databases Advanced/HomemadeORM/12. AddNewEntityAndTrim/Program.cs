namespace _12.AddNewEntityAndTrim
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;
    using HomemadeORM;
    using HomemadeORM.Entities;

    class Program
    {
        static void Main()
        {
            ConnectionStringBuilder builder = new ConnectionStringBuilder("Test2");
            string connectionString = builder.ConnectionString;

            EntityManager manager = new EntityManager(connectionString, true);
            Book book1 = new Book("TheBible", "God", DateTime.Parse("330-11-05 16:20:20"), "Ancient Greek", true);
            Book book2 = new Book("MeinKampf", "Chicho Adi", DateTime.Parse("1925-07-18 10:00:00"), "German", false);
            Book book3 = new Book(@"Hitchhikers Guide To The Galaxy", "Douglas Adams",DateTime.Parse("1995-04-20 13:38:00"), "English", true);
            manager.Persist(book1);
            manager.Persist(book2);
            manager.Persist(book3);
            TrimTitlesLongerThan(manager, 30);
           
        }

        public static void TrimTitlesLongerThan(EntityManager manager, int n)
        {
            // programmatic way of completing the task
            var booksWithLengthOver = manager.FindAll<Book>($"WHERE LEN(Title) > {n}").ToList();
            foreach (var book in booksWithLengthOver)
            {
                book.Title = book.Title.Remove(n, book.Title.Length-n);
                manager.Persist(book);
            }
            Console.WriteLine(booksWithLengthOver.Count + " books have now title length of " + n);

            // sql way of completing the task
            // string trimTitleSqlQuery = $@"UPDATE Books " +
            //                          $@"SET Title = STUFF(Title, {n}, LEN(Title),'') " +
            //                          $"WHERE LEN(Title) > {n}";
        }
    }
}
