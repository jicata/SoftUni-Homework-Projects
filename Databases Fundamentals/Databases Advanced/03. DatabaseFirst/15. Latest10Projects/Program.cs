namespace _15.Latest10Projects
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

            var projects = context.Projects.OrderByDescending(p => p.StartDate).Take(10);
            foreach (var project in projects.OrderBy(p => p.Name))
            {
                Console.WriteLine($"{project.Name} {project.Description} {project.StartDate} {project.EndDate}");
            }

            using (StreamWriter writer = new StreamWriter(@"D:\output.txt"))
            {
                Console.SetOut(writer);
                foreach (var project in projects.OrderBy(p => p.Name))
                {
                    Console.WriteLine($"{project.Name} {project.Description} {project.StartDate} {project.EndDate}");
                }
            }
        }
    }
}
