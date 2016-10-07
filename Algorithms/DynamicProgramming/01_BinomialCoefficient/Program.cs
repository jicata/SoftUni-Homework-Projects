namespace _01_BinomialCoefficient
{
    using System;

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int[] firstRow = new int[n + 1];
            int[] secondRow = new int[n + 1];

            firstRow[0] = 1;
            secondRow[0] = 1;
            secondRow[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                if (i%2 == 0)
                {
                    for (int j = 1; j < i; j++)
                    {
                        firstRow[j] = secondRow[j - 1] + secondRow[j];
                    }
                    firstRow[i] = 1;
                }
                else
                {
                    for (int j = 1; j < i; j++)
                    {
                        secondRow[j] = firstRow[j - 1] + firstRow[j];
                    }
                    secondRow[i] = 1;
                }

            }
            if (n%2 == 0)
            {
                Console.WriteLine(firstRow[k]);
                
            }
            else
            {
                Console.WriteLine(secondRow[k]);
            }
        }
    }
}
