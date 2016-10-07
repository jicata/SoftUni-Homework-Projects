namespace _02_URLReplacer
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            
            string input = Console.ReadLine();
            
            string pattern = @"<a href=(['""""])(http:\/\/\w+\.\w+)(?:\1>)(\w+)<\/a>";
            Regex rgx = new Regex(pattern);
            string replace = "[URL href=$2]$3[/URL]";

            string final = Regex.Replace(input, pattern, replace);

            Console.WriteLine(final);
        }
    }
}
