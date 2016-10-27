namespace _03.EmployeesFullInfo
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using SoftUniDBLib;
    using SoftUniDBLib.Models;

    class Program
    {
        static void Main()
        {
            SoftUniDBContext dbContext = new SoftUniDBContext();

            var employees =
                dbContext.Employees.Select(e => new {e.FirstName, e.LastName, e.MiddleName, e.JobTitle, e.Salary})
                    .ToList();

            
            using (StreamWriter writer = new StreamWriter(@"D:\output.txt"))
            {
                Console.SetOut(writer);
                employees.ForEach(x => Console.WriteLine($"{x.FirstName} {x.LastName} {x.MiddleName} {x.JobTitle} {x.Salary}"));
            }
        }
    }
}
