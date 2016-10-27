namespace _10.Employee147
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
            var employee147 = context.Employees.FirstOrDefault(e => e.EmployeeID == 147);

            Console.WriteLine($@"{employee147.FirstName} {employee147.LastName} {employee147.JobTitle}");
            foreach (var project in employee147.Projects.OrderBy(p=>p.Name))
            {
                Console.WriteLine($"{project.Name}");
            }

            using (StreamWriter writer = new StreamWriter(@"D:\output.txt"))
            {
                Console.SetOut(writer);
                Console.WriteLine($@"{employee147.FirstName} {employee147.LastName} {employee147.JobTitle}");
                foreach (var project in employee147.Projects.OrderBy(p=>p.Name))
                {
                    Console.WriteLine($"{project.Name}");
                }
            }
        }
    }
}
