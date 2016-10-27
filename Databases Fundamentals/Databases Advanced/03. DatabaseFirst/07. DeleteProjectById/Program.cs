namespace _07.DeleteProjectById
{
    using System;
    using System.IO;
    using System.Linq;
    using SoftUniDBLib;
    using SoftUniDBLib.Models;

    class Program
    {
        static void Main()
        {
            SoftUniDBContext context = new SoftUniDBContext();
            var project = context.Projects.FirstOrDefault(p => p.ProjectID == 2); //hardcoded - switch up to userinput

            // using SELECT before Contains because joining tables from Database to tables in memory is illegal
            var employeesOnProject =
                context.Employees.Where(e => e.Projects.Select(p => p.ProjectID).Contains(project.ProjectID)).ToList(); 
            foreach (var employee in employeesOnProject)
            {
                employee.Projects.Remove(project);
            }

            context.Projects.Remove(project);

            context.SaveChanges();

            var projects = context.Projects.Select(p => p.Name).Take(10).ToList();
            projects.ForEach(x=>Console.WriteLine(x));


            using (StreamWriter writer = new StreamWriter(@"D:\output.txt"))
            {
                Console.SetOut(writer);
                projects.ForEach(x => Console.WriteLine(x));
            }




        }

    }
}
