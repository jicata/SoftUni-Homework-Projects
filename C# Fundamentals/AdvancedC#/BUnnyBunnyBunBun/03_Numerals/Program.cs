namespace _03_Numerals
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Numerics;
    using System.Text;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            string softUniNumber = Console.ReadLine();
            string pattern = @"(aa)|(aba)|(bcc)|(cc)|(cdc)";
            Regex numericMatcher = new Regex(pattern);
            StringBuilder sb = new StringBuilder();
            if (numericMatcher.IsMatch(softUniNumber))
            {
                var matchs = numericMatcher.Matches(softUniNumber);
                foreach (Match m in matchs)
                {
                    string mValue = m.Value;
                    switch (mValue)
                    {
                        case "aa":
                            sb.Append(0);
                            break;
                        case "aba":
                            sb.Append(1);
                            break;
                        case "bcc":
                            sb.Append(2);
                            break;
                        case "cc":
                            sb.Append(3);
                            break;
                        case "cdc":
                            sb.Append(4);
                            break;
                    }
                }

            }
            BigInteger finalNumber = BaseFiveToBaseTen(sb.ToString());
          
            Console.WriteLine(finalNumber);

        }

        private static BigInteger BaseFiveToBaseTen(string toString)
        {
            int count = 0;
            BigInteger kurac = BigInteger.Parse(toString, NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint);
            string numberAsString = kurac.ToString("R");
            BigInteger newNumber = BigInteger.Zero;
            for (long i = numberAsString.Length-1; i >= 0; i--)
            {
                long chakai = long.Parse(numberAsString[count].ToString());
                BigInteger result = chakai * (BigInteger)Math.Pow(5, i);
                newNumber = newNumber + result;
                count++;
            }
            return newNumber;
        }

    }
}
