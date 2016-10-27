namespace _04.EmployeesWithSalaryOver50k
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
            var employees = context.Employees.Where(e => e.Salary > 50000).Select(e => e.FirstName).ToList();
            using (StreamWriter writer = new StreamWriter(@"D:\output.txt"))
            {
                Console.SetOut(writer);
                employees.ForEach(x => Console.WriteLine(x));
            }
        }
    }
}
