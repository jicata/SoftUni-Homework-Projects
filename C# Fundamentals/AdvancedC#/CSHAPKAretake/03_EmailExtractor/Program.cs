namespace _03_EmailExtractor
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"([a-zA-Z]+[\.-_]?[a-zA-Z]*?@\w+(?:\.\w+)?\.\w+)";
            Regex rgx = new Regex(pattern);

            List<string> emails = new List<string>();

            var matches = rgx.Matches(input);

            foreach (Match match in matches)
            {
                emails.Add(match.Value.ToString());
            }

            Console.WriteLine(string.Join(", ", emails));
            
        }
    }
}
