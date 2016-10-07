namespace TextTransformer
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            string line = Console.ReadLine();
            StringBuilder builder = new StringBuilder();
            while (line != "burp")
            {
                builder.Append(line);
                line = Console.ReadLine();
            }
            
            string noEmptySpaces = Regex.Replace(builder.ToString(),@"\s+", " ");

 
            string pattern = @"([$%&'])([^$%&']+)\1";
            Regex ragu = new Regex(pattern);
            MatchCollection matches = ragu.Matches(noEmptySpaces);
            List<string> translatedStrings = new List<string>();
            foreach (Match match in matches)
            {
                string specialSymbol = match.Groups[1].ToString();
                int specialSymbolValue = AssertSpecialSymbolWeight(specialSymbol);
                string toInterpret = match.Groups[2].ToString();
                StringBuilder finalBuilder = new StringBuilder();
                if (!String.IsNullOrEmpty(toInterpret) && !String.IsNullOrWhiteSpace(toInterpret))
                {
                    for (int i = 0; i < toInterpret.Length; i++)
                    {
                        char transformedChar = ' ';
                        if (i % 2 == 0)
                        {
                            transformedChar = (char)((int)toInterpret[i] + specialSymbolValue);
                        }
                        else
                        {
                            transformedChar = (char)((int)toInterpret[i] - specialSymbolValue);
                        }
                        finalBuilder.Append(transformedChar);
                    }
                    translatedStrings.Add(finalBuilder.ToString());
                }
               
            }
            Console.WriteLine(string.Join(" ", translatedStrings));
        }

        private static int AssertSpecialSymbolWeight(string specialSymbol)
        {
            int specialSymbolValue = 0;
            switch (specialSymbol)
            {
                case "$":
                    specialSymbolValue = 1;
                    break;
                case "%":
                    specialSymbolValue = 2;
                    break;
                case "&":
                    specialSymbolValue = 3;
                    break;
                case "'":
                    specialSymbolValue = 4;
                    break;
            }
            return specialSymbolValue;
        }
    }
}
