namespace _16.IncreaseSalaries
{
    using System;
    using System.IO;
    using System.Linq;
    using SoftUniDBLib;

    class Program
    {
        static void Main()
        {
            SoftUniDBContext context = new SoftUniDBContext();


            string[] departments = new[]
            {
                "Engineering",
                "Tool Design",
                "Marketing",
                "Information Services"
            };

            var employees = context.Employees.Where(e => departments.Contains(e.Department.Name));
            foreach (var employee in employees)
            {
                employee.Salary *= 1.12m;
                Console.WriteLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:F6})");
            }
            context.SaveChanges();

            using (StreamWriter writer = new StreamWriter(@"D:\output.txt"))
            {
                Console.SetOut(writer);
                foreach (var employee in employees)
                {
                    Console.WriteLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:F6})");
                }
            }

        }
    }
}
