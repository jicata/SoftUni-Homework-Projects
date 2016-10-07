using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace oddLines
{
    class Program
    {
        static void Main()
        {
            string path = @"..\..\fileche.txt";
            StreamReader reader = new StreamReader(path);
            using(reader)
            {
                int counter = 0;
                string line = reader.ReadLine();
                while (line!= null)
                {

                    if (counter == 0 || counter %2 == 0)
                    {
                        Console.WriteLine(line);
                    }
                    counter++;
                    line = reader.ReadLine();
                }
            }

        }
    }
}
