using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _03.Extract_Emails
{
    class Program
    {
        static void Main()

        {
           
            string userInput = Console.ReadLine();
            string pattern = @"(?<=\s|^)([a-z0-9]+(?:[_.-][a-z0-9]+)*@[a-z]+\-?[a-z]+(?:\.[a-z]+)+)\b";
            //               @"(?<=\s|^)([a-z0-9]+(?:[_.-][a-z0-9]+)*@[a-z]+\-?[a-z]+(?:\.[a-z]+)+)\b";
            Regex regExmail = new Regex(pattern);
            MatchCollection matches = regExmail.Matches(userInput);
            foreach (Match mail in matches)
            {
                Console.WriteLine(mail.Groups[0]);
            }

          
        }
    }
}
