namespace _11.DepartmentsWithMoreThan5
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

            var deps = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count);
                //.Select(d => new {d.Name, d.Manager.FirstName, d.Employees});

            foreach (var dep in deps)
            {
                Console.WriteLine($"{dep.Name} {dep.Manager.FirstName}");
                var emps = dep.Employees.Select(e=>new {e.FirstName, e.LastName, e.JobTitle});
                foreach (var emp in emps)
                {
                    Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.JobTitle}");
                }
            }
            using (StreamWriter writer = new StreamWriter(@"D:\output.txt"))
            {
                Console.SetOut(writer);
                foreach (var dep in deps)
                {
                    Console.WriteLine($"{dep.Name} {dep.Manager.FirstName}");
                    var emps = dep.Employees.Select(e => new { e.FirstName, e.LastName, e.JobTitle });
                    foreach (var emp in emps)
                    {
                        Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.JobTitle}");
                    }
                }
            }
        }   
    }
}
