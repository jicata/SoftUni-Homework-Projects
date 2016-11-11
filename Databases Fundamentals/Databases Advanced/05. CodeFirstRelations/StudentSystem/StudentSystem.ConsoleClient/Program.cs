namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.SqlServer;
    using System.Linq;
    using Data;
    using Data.Migrations;
    using Models;


    class Program
    {
        static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemContext, Configuration>());
            StudentSystemContext context = new StudentSystemContext();

            // 01. All students with their homework
            var studentsWithHomewrk = context.Students
                .Select(s => new { s.Name, Homework = s.Homeworks.Select(h => new { h.Content, h.ContentType }).ToList() })
                .ToList();

            //foreach (var student in studentsWithHomewrk)
            //{
            //    Console.WriteLine(student.Name);
            //    foreach (var homework in student.Homework)
            //    {
            //        Console.WriteLine($"Type: {homework.ContentType}, Content: {homework.Content}");
            //    }
            //}

            // 02. All courses and their resources

            var coursesAndResources =
                context.Courses.OrderBy(c => c.StartDate)
                    .ThenByDescending(c => c.EndDate)
                    .Select(c => new {c.Name, c.Description, c.Resources});

            //foreach (var courses in coursesAndResources)
            //{
            //    Console.WriteLine($"Course name: {courses.Name}, Course description: {courses.Description}");
            //    foreach (var resource in courses.Resources)
            //    {
            //        Console.WriteLine(resource);
            //    }
            //}

            // 03. All courses with more than 5 resources (haven't seeded such but oh well)

            context.Courses
                .Where(c=>c.Resources.Count > 5)
                .OrderByDescending(c => c.Resources.Count)
                .ThenByDescending(c => c.StartDate)
                .Select(c => new {c.Name, c.StartDate})
                .ToList();
                //.ForEach(x => Console.WriteLine($"{x.Name} {x.StartDate}"));

            // 04. Active courses on a given date and students in 'em

            DateTime dateTime = DateTime.Parse("2016-08-01");


            context.Courses.Where(c => c.StartDate < dateTime && c.EndDate > dateTime)
                .OrderByDescending(c => c.Students.Count)
                .ThenByDescending(c=> SqlFunctions.DateDiff("day", c.StartDate, c.EndDate))
                .Select(
                    c => new {c.Name, c.StartDate, c.EndDate, Duration = SqlFunctions.DateDiff("day", c.StartDate, c.EndDate), c.Students.Count})
                .ToList();
                //.ForEach(
                //    x =>
                //        Console.WriteLine(
                //            $"Course: {x.Name} Period: {x.StartDate} - {x.EndDate} ({x.Duration} days). Attented by {x.Count} students "));

            // 05. All courses for students and some aggregates

            context.Students
                .Where(s=>s.Courses.Any())
                .OrderByDescending(s => s.Courses.Sum(c=>c.Price))
                .ThenByDescending(s => s.Courses.Count)
                .ThenBy(s => s.Name)
                .Select(
                    s =>
                        new
                        {
                            s.Name,
                            s.Courses.Count,
                            AvgPrice = s.Courses.Select(c => c.Price).Average(),
                            Total = s.Courses.Sum(c=>c.Price)
                        })
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Name} {x.Count} {x.AvgPrice} {x.Total}"));

            // 08. TagAttribute

        }
    }
}
