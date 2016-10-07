namespace _02_Cable
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        public static int[] cableCosts;
        static void Main()
        {
            cableCosts = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int addedCost = int.Parse(Console.ReadLine());
            int[] values = new int[8];
            values[0] = 0;
            for (int i = 1; i < values.Length; i++)
            {
                values[i] = i;
            }
            int[] maxPrices = bestPrice(cableCosts.Length, addedCost);
            //Console.WriteLine(string.Join(" ", maxPrices.Skip(0)));
            for (int i = 1; i < maxPrices.Length; i++)
            {
                Console.Write(maxPrices[i] + " ");
            }
            Console.WriteLine();
        }
        public static int[] bestPrice(int n, int addedCost)
        {

            // This works like a cache -> tova e napulno
            int[] maxPrices = new int[n + 1];

            // The trick here is to work from the bottom up -> i izcqlo 
            for (int i = 1; i <= n; i++)
            {

                int max_price = cableCosts[i - 1]; // Without cuts -> sobstveno i 

                // Try all cuts length with combo from existing cache -> originalno reshenie
                for (int j = 1; j < i; j++)
                {
                    int cutUpCost = (maxPrices[i - j] + cableCosts[j - 1])-2*addedCost;
                    max_price = Math.Max(max_price,cutUpCost);
                }
                maxPrices[i] = max_price;
            }

            return maxPrices;

        }
    }
}
