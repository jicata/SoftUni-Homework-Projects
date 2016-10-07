namespace LoggerLib
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Interfaces;
    using Models;

    public class Program
    {
        public static void Main(string[] args)
        {
            //ILayout layout = new SimpleLayout();
            //IAppender appender = new ConsoleAppender(layout);
            //ILogger logger = new Logger(appender);

            //logger.LogError("Error parsing JSON.");
            //logger.LogInfo(string.Format("User {0} successfully registered.", "Pesho"));

            var nz = new peeras();
            Console.WriteLine(nz.HasAids);
            nz.Name = "da";
            Console.WriteLine(nz.HasAids);
        }
    }
}
