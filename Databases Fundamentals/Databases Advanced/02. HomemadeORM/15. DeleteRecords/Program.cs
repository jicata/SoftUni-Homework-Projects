namespace _15.DeleteRecords
{
    using System;
    using HomemadeORM;
    using _12.AddNewEntityAndTrim;

    class Program
    {
        static void Main()
        {
            ConnectionStringBuilder builder = new ConnectionStringBuilder("Test2");
            string connectionString = builder.ConnectionString;

            EntityManager manager = new EntityManager(connectionString, true);
            Book book1 = new Book("TheBible", "God", DateTime.Parse("0330-11-05 16:20:20"), "Ancient Greek", true, 2);
            Book book2 = new Book("MeinKampf", "Chicho Adi", DateTime.Parse("1925-07-18 10:00:00"), "German", false, 1);
            Book book3 = new Book(@"Hitchhikers Guide To The Galaxy", "Douglas Adams", DateTime.Parse("1995-04-20 13:38:00"), "English", true, 8);
            manager.Persist(book1);
            manager.Persist(book2);
            manager.Persist(book3);
            DeleteBooksUnderRating(manager);

        }

        public static void DeleteBooksUnderRating(EntityManager manager)
        {
            Console.WriteLine($@"{manager.DeleteAll<Book>("WHERE Rating < 2")} books have been deleted from the database");

        }
    }
}
