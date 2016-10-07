using System;
using System.Numerics;


namespace basicCombinatorics
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            BigInteger factorialN = 1;
            BigInteger factorialK = 1;
            BigInteger factorialNK = 1;

            for (int i = 1; i <= n; i++)
            {
                factorialN *= i;
                if (i <= k)
                {
                    factorialK *= i;
                }
                if (i<= n-k)
                {
                    factorialNK *= i;
                }
            }
            BigInteger putItTogether = factorialN / (factorialK * factorialNK);
            Console.WriteLine(putItTogether);
        }
    }
}
