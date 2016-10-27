namespace _18.EmployeesStartingWithSA
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

            var SAemployess =
                context.Employees.Where(e => e.FirstName.StartsWith("SA"))
                    .Select(e => new {e.FirstName, e.LastName, e.JobTitle, e.Salary});

            foreach (var employee in SAemployess)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary})");
            }

            using (StreamWriter writer = new StreamWriter(@"D:\output.txt"))
            {
                Console.SetOut(writer);
                foreach (var employee in SAemployess)
                {
                    Console.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary})");
                }
            }
        }
    }
}
