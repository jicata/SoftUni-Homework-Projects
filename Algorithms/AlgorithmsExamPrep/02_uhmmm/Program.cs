using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_uhmmm
{
    class Program
    {
        static void Main(string[] args)
        {

            
        }
        public static int bestPrice(int n)
        {

            // This works like a cache
            int[] maxPrices = new int[n + 1];

            // The trick here is to work from the bottom up
            for (int i = 1; i <= n; i++)
            {

                int max_price = prices[i - 1]; // Without cuts

                // Try all cuts length with combo from existing cache
                for (int j = 1; j < i; j++)
                {
                    max_price = Math.max(max_price, maxPrices[i - j] + prices[j - 1]);
                }
                maxPrices[i] = max_price;
            }

            return maxPrices[n];

        }
    }
}
    

