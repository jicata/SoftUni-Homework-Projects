namespace ConsoleClient
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Data;
    using Data.Migrations;

    class Program
    {
        static void Main()
        {
            var strategy = new MigrateDatabaseToLatestVersion<BookShopContext, Configuration>();
            Database.SetInitializer(strategy);

            var context = new BookShopContext();
            // 01. All books after 2000
            context.Books.Where(b => b.ReleaseDate.Value.Year > 2000)
                .Select(b => b.Title)
                .ToList();
                //.ForEach(b=>Console.WriteLine(b));

            // 02. All authors with at least one book before 1990

            context.Authors.Where(a => a.Books.Select(b => b.ReleaseDate).Any(b => b.Value.Year < 1990))
                .Select(a => new {a.FirstName, a.LastName})
                .OrderBy(a => a.FirstName)
                .ToList();
                //.ForEach(a => Console.WriteLine($"{a.FirstName} {a.LastName}"));
            
            // 03. All authors ordered by book count

            context.Authors.OrderByDescending(a => a.Books.Count)
                .Select(a => new {a.FirstName, a.LastName, a.Books.Count})
                .ToList();
                //.ForEach(x => Console.WriteLine($"{x.FirstName} {x.LastName} {x.Count}"));

            // 04. All books from George Powell

            context.Books.Where(b => b.Author.FirstName == "George" && b.Author.LastName == "Powell")
                .OrderByDescending(b => b.ReleaseDate)
                .ThenBy(b => b.Title)
                .Select(b => new {b.Title, b.ReleaseDate, b.Copies})
                .ToList();
                //.ForEach( b =>Console.WriteLine($"Title: {b.Title}, Released On: {b.ReleaseDate}, Number Of Copies: {b.Copies}"));

            // 05. Most recent books by categories

            var categories = context.Categories.OrderByDescending(c => c.Books.Count)
                .Select(c => new {c.Name, Books = c.Books.OrderByDescending(b => b.ReleaseDate).ThenBy(b => b.Title).Take(3).Select(b => new { b.Title, b.ReleaseDate }).ToList()});

            foreach (var category in categories)
            {
                Console.WriteLine($"--{category.Name}: {category.Books.Count}");

                Console.WriteLine(string.Join("\\n", category.Books));
                
            }

            // 06. Related Books

            var books = context.Books.Take(3).ToList();
            books[0].RelatedBooks.Add(books[1]);
            books[1].RelatedBooks.Add(books[0]);
            books[2].RelatedBooks.Add(books[0]);
            books[0].RelatedBooks.Add(books[2]);

            context.SaveChanges();

            var booksAndRelatedBooks = context.Books.Take(3).Select(b => new {b.Title, b.RelatedBooks});
            //foreach (var book in booksAndRelatedBooks)
            //{
            //    Console.WriteLine($"--{book.Title}");
            //    foreach (var relatedBook in book.RelatedBooks)
            //    {
            //        Console.WriteLine(relatedBook.Title);
            //    }
            //}
        }
    }
}
