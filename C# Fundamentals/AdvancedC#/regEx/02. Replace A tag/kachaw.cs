using System;
using System.Text.RegularExpressions;

namespace _02.Replace_A_tag
{
    class kachaw
    {
        static void Main()
        {


            string text = Console.ReadLine();
            while (text != "end")
            {
                string pattern = @"<a.*href=((?:.|\n)*?(?=>))>((?:.|\n)*?(?=<))<\/a>";
                string replace = @"[URL href=$1]$2[/URL]";
                var replaced = Regex.Replace(text, pattern, replace);
                Console.WriteLine(replaced);
                text = Console.ReadLine();
            }

        }
    }
}
