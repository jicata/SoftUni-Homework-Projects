namespace Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using Models;
    using Models.Enums;

    public sealed class Configuration : DbMigrationsConfiguration<Data.BookShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;       
            ContextKey = "Data.BookShopContext";
        }


      
        protected override void Seed(BookShopContext context)
        {
            if (context.Books.Any())
            {
                return;
            }

            SeedAuthors(context);

            SeedCategories(context);

            SeedBooks(context);
        }

        private static void SeedBooks(BookShopContext context)
        {
            int authorsCount = context.Authors.Count();
            int categoriesCount = context.Categories.Count();

            using (
                var reader =
                    new StreamReader(
                        @"C:\Users\Maika\Documents\Programming\Homework\Databases Fundamentals\Databases Advanced\books.txt"))
            {
                var line = reader.ReadLine();
                line = reader.ReadLine();
                while (line != null)
                {
                    var random = new Random();
                    var randomAuthorIndex = random.Next(0, authorsCount);
                    var author = context.Authors.Find(randomAuthorIndex);
                    var randomCategoryIndex = random.Next(0, categoriesCount);
                    var category = context.Categories.Find(randomCategoryIndex);

                    var data = line.Split(new[] {' '}, 6);
                    var edition = (EditionType) int.Parse(data[0]);
                    var releaseDate = DateTime.ParseExact(data[1], "d/M/yyyy", CultureInfo.InvariantCulture);
                    var copies = int.Parse(data[2]);
                    var price = decimal.Parse(data[3]);
                    var ageRestriction = (AgeRestriction) int.Parse(data[4]);
                    var title = data[5];

                    context.Books.Add(new Book()
                    {
                        Author = author,
                        EditionType = edition,
                        ReleaseDate = releaseDate,
                        Copies = copies,
                        Price = price,
                        AgeRestriction = ageRestriction,
                        Title = title
                    }).Categories.Add(category);

                    line = reader.ReadLine();
                }
            }
            context.SaveChanges();
        }

        private static void SeedCategories(BookShopContext context)
        {
            var categories =
                File.ReadAllLines(
                    @"C:\Users\Maika\Documents\Programming\Homework\Databases Fundamentals\Databases Advanced\categories.txt")
                    .Skip(1)
                    .ToArray();
            foreach (var category in categories)
            {
                context.Categories.Add(new Category() {Name = category});
            }
            context.SaveChanges();
        }

        private static void SeedAuthors(BookShopContext context)
        {
            var authors =
                File.ReadAllLines(
                    @"C:\Users\Maika\Documents\Programming\Homework\Databases Fundamentals\Databases Advanced\authors.txt")
                    .Skip(1)
                    .ToArray();
            foreach (var author in authors)
            {
                string authorFirst = author.Split()[0];
                string authorLast = author.Split()[1];
                context.Authors.Add(new Author() {FirstName = authorFirst, LastName = authorLast});
            }
            context.SaveChanges();
        }
    }
}
