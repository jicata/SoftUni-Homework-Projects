namespace _08.FindEmployeesInPeriod
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using SoftUniDBLib;

    class Program
    {
        static void Main()
        {
            SoftUniDBContext context = new SoftUniDBContext();
            DateTime startDate = DateTime.Parse("2001.01.01");
            DateTime endDate = DateTime.Parse("2003.01.01");

            var thirtyEmployees = context.Employees
                .Where(e => e.Projects.Any(p => p.StartDate >= startDate && p.StartDate <= endDate))
                .Take(30)
                .Select(e => new { e.FirstName, e.LastName, managerName = e.Manager.FirstName, e.Projects});

            foreach (var employee in thirtyEmployees)
            {
                Console.Write($"{employee.FirstName} {employee.LastName} {employee.managerName} ");
                foreach (var project in employee.Projects)
                {
                    Console.Write($"--{project.Name} {project.StartDate.ToString("G", CultureInfo.DefaultThreadCurrentCulture)} ");
                    if (project.EndDate.HasValue)
                    {
                        Console.WriteLine(project.EndDate.Value.ToString("G", CultureInfo.DefaultThreadCurrentCulture));
                    }
                }
            }


            using (StreamWriter writer = new StreamWriter(@"D:\output.txt"))
            {
                Console.SetOut(writer);
                foreach (var employee in thirtyEmployees)
                {
                    Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.managerName}");
                    foreach (var project in employee.Projects)
                    {
                        Console.Write($"--{project.Name} {project.StartDate.ToString("G", CultureInfo.CreateSpecificCulture("en-us"))} ");
                        if (project.EndDate.HasValue)
                        {
                            Console.WriteLine(project.EndDate.Value.ToString("G", CultureInfo.CreateSpecificCulture("en-us")));
                        }
                    }
                }
            }

        }
    }
}
