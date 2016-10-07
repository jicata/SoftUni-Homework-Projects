using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _02.Line_Numbers
{
    class lineNumbers
    {
        static void Main()
        {
            string path = @"..\..\fileche.txt";
            string toPath = @"..\..\lineNumbers.txt";
            StreamReader reader = new StreamReader(path);
            
            //FileStream creator = new FileStream(toPath, FileMode.Create);
            //creator.Close();
            StreamWriter writer = new StreamWriter(toPath);
            
            using(reader)
            {
                using(writer)
                {
                    string line = reader.ReadLine();
                    int counter = 0;
                    while(line!=null)
                    {
                        writer.WriteLine("{0}. {1}", counter, line);
                        counter++;
                        line = reader.ReadLine();
                    }
              
                }
                
            }
        }
    }
}
