namespace RAGEEEEEEEEEEE
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    class Program
    {
        public static void Main()
        {
            string pattern = @"(\D+)(\d+)";
            Regex rageRegex = new Regex(pattern);

            string input = Console.ReadLine();

            var matches = rageRegex.Matches(input);

            StringBuilder sb = new StringBuilder();
            List<char> uniqueChars = new List<char>();
            foreach (Match match in matches)
            {
                string toBeRepeated = match.Groups[1].ToString();
                int timesRepeat = int.Parse(match.Groups[2].ToString());
                for (int i = 0; i < timesRepeat; i++)
                {
                    sb.Append(toBeRepeated.ToUpper());
                }
                
            }
            int kur = sb.ToString().Distinct().Count();
    
            Console.WriteLine("Unique symbols used: " + kur);
            Console.WriteLine(sb.ToString());
        }
    }
}
