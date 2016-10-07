namespace _01_ConsecutiveLetters
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            string input = "aaaaabbbbbcdddeeeedssaa";
            Regex regx = new Regex(@"((\w)\2+)");
            string kur = regx.Replace(input, "$2");
            

            Console.WriteLine(kur);

        }
    }
}
