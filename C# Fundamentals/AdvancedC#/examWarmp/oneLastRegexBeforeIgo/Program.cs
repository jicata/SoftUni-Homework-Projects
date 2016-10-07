using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace oneLastRegexBeforeIgo
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string leInput= Console.ReadLine();
            string theWholeThang = string.Empty;
            while(leInput!="END")
            {
                 theWholeThang += leInput;
                 leInput = Console.ReadLine();
            }
            Dictionary<string, string> phoneBook = new Dictionary<string, string>();
            
            string pattern = @"([A-Z]\w+)(?:[^A-Z\d+])*(\+?\d+[\(\)\/\.\-\s]*\d+[\(\)\/\.\-\s]*\d+[\(\)\/\.\-\s]?\d+)";

            Regex rgx = new Regex(pattern);

            MatchCollection matches = rgx.Matches(theWholeThang);

                

            foreach (Match match in matches)
            {
                string name = match.Groups[1].Value;
                string number = match.Groups[2].Value;
                phoneBook.Add(name, number);
            }
                
            
            foreach (KeyValuePair<string,string> key in phoneBook)
            {
                Console.WriteLine("{0} - {1}",key.Key, key.Value );
            }
            
            
        }
    }
}
