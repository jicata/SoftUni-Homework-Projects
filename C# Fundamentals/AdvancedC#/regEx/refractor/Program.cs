using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace refractor
{
    class Program
    {
        static void Main()
        {
            StreamReader reader = new StreamReader(@"C:\Users\Maika\Desktop\softa we\advanced c#\Mecanismo.cs");
            using (reader)
            {
                string whiteSpaceFormat = string.Empty;
                string pattern = string.Empty;
                string line = reader.ReadLine();
                string theWholeText = string.Empty;
                while (line != null)
                {
                    theWholeText += line;
                    line = reader.ReadLine();
                    Regex whiteSpacePattern = new Regex(@"\s+\n\s+");
                    pattern = @"\s*\n\s*";
                    
                    
                }
                string newLine = Environment.NewLine;
                whiteSpaceFormat = Regex.Replace(theWholeText, pattern, newLine);
                string oshtePattern = @"\;\s+";
                string asd = Regex.Replace(whiteSpaceFormat, oshtePattern, ';'+newLine);
                Console.WriteLine(asd);

            }
        }
    }
}
