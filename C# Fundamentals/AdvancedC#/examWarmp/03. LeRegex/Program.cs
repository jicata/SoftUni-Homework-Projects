using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _03.LeRegex
{
    class Program
    {
        static void Main(string[] args)
        {
            string patternDouble = @"double\s([^A-Z]\w*)";
            string patternInt = @"int\s([^A-Z]\w*)";

            StringBuilder theWholeInput = new StringBuilder();
            string userInput = Console.ReadLine();
            while (userInput != "//END_OF_CODE")
            {
                string whiteSpace = @"\s+";
                string readeableText = Regex.Replace(userInput, whiteSpace, " ");
                theWholeInput.Append(readeableText);
                userInput = Console.ReadLine();
            }
            string fuckSb = theWholeInput.ToString();
            var dblRgx = new Regex(patternDouble);
            var intRgx = new Regex(patternInt);
            MatchCollection dblMatches = dblRgx.Matches(fuckSb);
            MatchCollection intMatches = intRgx.Matches(fuckSb);

            List<string> dbls = new List<string>();
            
            foreach (Match dblMatch in dblMatches)
            {
                dbls.Add(dblMatch.Groups[1].Value);
            }
            List<string> ints = new List<string>();
            
            foreach (Match intMatch in intMatches)
            {
                ints.Add(intMatch.Groups[1].Value);
            }
            ints.Sort();
            dbls.Sort();
            Console.Write("Doubles: ");
            if (dbls.Count > 0)
            {
                Console.Write(string.Join(", ", dbls));
            }
            else
            {
                Console.Write("None");
            }
           
            Console.WriteLine();
            Console.Write("Ints: ");
            if(ints.Count > 0)
            {
                Console.Write(string.Join(", ", ints));
            }
            
            
            else
            {
                Console.Write("None");
            }
            
            Console.WriteLine();

           
        }
    }
}
