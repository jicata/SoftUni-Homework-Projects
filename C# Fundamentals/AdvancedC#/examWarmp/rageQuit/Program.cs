using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace rageQuit
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"([\D]+)([\d]+)";
            var rgx = new Regex(pattern);
            StringBuilder builder = new StringBuilder();

            MatchCollection matches = rgx.Matches(input);

            foreach (Match match in matches)
            {
                StringBuilder sb = new StringBuilder();
                var message = match.Groups[1].Value.ToUpper();
                var numberOfRepetitions = int.Parse(match.Groups[2].Value);

                for (int i = 0; i < numberOfRepetitions; i++)
                {
                    sb.Append(message);
                }
                builder.Append(sb);
            }
            int count = builder.ToString().Distinct().Count();
            
            Console.WriteLine("Unique symbols used: {0}", count);
            Console.WriteLine(builder);

        }
    }
}
