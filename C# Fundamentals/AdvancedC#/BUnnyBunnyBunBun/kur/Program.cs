namespace ragguEx
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
            string doublePattern = @"double ([a-z][a-zA-Z]*?)\b";
            string intPattern = @"int ([a-z][a-zA-Z]*?)\b";

            Regex doubleMatcher = new Regex(doublePattern);
            Regex intMatcher = new Regex(intPattern);

            StringBuilder sb = new StringBuilder();
            string input = Console.ReadLine();
            while (input != "//END_OF_CODE")
            {
                sb.Append(input);
                input = Console.ReadLine();
            }
            List<string> doubles = new List<string>();
            List<string> integers = new List<string>();

            var doubleMatches = doubleMatcher.Matches(sb.ToString());
            var intMatches = intMatcher.Matches(sb.ToString());

            foreach (Match match in doubleMatches)
            {
                doubles.Add(match.Groups[1].Value);
            }

            foreach (Match match in intMatches)
            {
                integers.Add(match.Groups[1].Value);
            }

            doubles.Sort();
            integers.Sort();

            if (doubles.Any())
            {
                Console.WriteLine("Doubles: " + string.Join(", ", doubles));
            }
            else
            {
                Console.WriteLine("Doubles: None");
            }

            if (integers.Any())
            {
                Console.WriteLine("Ints: " + string.Join(", ", integers));
            }
            else
            {
                Console.WriteLine("Ints: None");
            }
            
        }
    }
}
