using System;
using System.Numerics;

namespace trailingZeros
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger factorial = 1;
            string zero = string.Empty;
            string trailingZero = string.Empty;
            for (int i = 1; i <= n; i++)
            {
                factorial = factorial * i;
            }
            string factorialString = factorial.ToString();
            char[] factorialArray = factorialString.ToCharArray();
            Array.Reverse(factorialArray);

            foreach(char ch in factorialArray)
            {
                string character = ch.ToString();
                if (character == "0")
                {
                    trailingZero += character;
                }
                else if (character != "0")
                {
                    Console.WriteLine(trailingZero.Length);
                    break;
                }
            }
        }
    }
}
