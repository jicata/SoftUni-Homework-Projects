namespace _05.EmployeesFromSeattle
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
            var seattlers = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new {e.FirstName, e.LastName, e.Department.Name, e.Salary})
                .ToList();

            seattlers.ForEach(x => Console.WriteLine($"{x.FirstName} {x.LastName} from {x.Name} - {x.Salary:F2}"));
           // return;
            using (StreamWriter writer = new StreamWriter(@"D:\output.txt"))
            {
                Console.SetOut(writer);
                seattlers.ForEach(x => Console.WriteLine($"{x.FirstName} {x.LastName} from {x.Name} - ${x.Salary:F2}"));
            }
        }
    }
}
