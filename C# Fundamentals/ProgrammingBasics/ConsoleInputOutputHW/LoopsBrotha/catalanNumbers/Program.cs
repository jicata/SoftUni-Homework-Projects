using System;
using System.Numerics;

namespace catalanNumbers
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger factorielN = 1;
            BigInteger factoriel2N = 1;
            BigInteger factorielN1 = 1;

            for (int i = 1; i <=n; i++)
            {
                factorielN *= i;
            }
            for (int j = 1; j<= 2*n; j++)
            {
                factoriel2N *= j;
            }
            for (int k = 1; k<= n+1; k++)
            {
                factorielN1 *= k;
            }
            BigInteger smetka = factoriel2N / (factorielN1 * factorielN);
            Console.WriteLine(smetka);
        }
    }
}
