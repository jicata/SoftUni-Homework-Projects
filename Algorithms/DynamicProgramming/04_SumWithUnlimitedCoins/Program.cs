namespace _04_SumWithUnlimitedCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;

    class Program
    {
        static void Main()
        {
            //mystery unsolved
            int targetSum = int.Parse(Console.ReadLine());
            int[] coins = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            
            int[,] sums = new int[coins.Length, targetSum+1];

            sums[0, 0] = 1;
            for (int sum = 0; sum <= targetSum; sum++)
            {
                if (sum % coins[0] == 0)
                {
                    sums[0,sum] = 1;
                }
            }

            for (int coin = 1; coin < coins.Length; coin++)
            {
                for (int sum = 0; sum <= targetSum; sum++)
                {
                    if (coins[coin] > sum)
                    {
                        sums[coin, sum] = sums[coin - 1, sum];
                    }
                    else
                    {                     
                        sums[coin, sum] = sums[coin - 1, sum] + sums[coin, sum - coins[coin]];
                    }
                }   
            }

            Console.WriteLine("MATRIX DP SOLUTION");
            Console.WriteLine(sums[coins.Length-1, targetSum]);
            Console.WriteLine();
            
            int[] sumsArray = new int[targetSum + 1];
            sumsArray[0] = 1;
            for (int coin = 0; coin < coins.Length; coin++)
            {
                int currentCoin = coins[coin];
                for (int sum = 0; sum < sumsArray.Length; sum++)
                {

                    if (currentCoin <= sum)
                    {
                        int newCombinationsAmount = sumsArray[sum] + sumsArray[sum - coins[coin]];
                        sumsArray[sum] = newCombinationsAmount;
                    }
                }
            }
            Console.WriteLine("ARRAY DP SOLUTION");
            
            Console.WriteLine(sumsArray[targetSum]);
        }

        private static void PrintMatrix(int[,] sums)
        {
            for (int i = 0; i < sums.GetLength(0); i++)
            {
                for (int j = 0; j < sums.GetLength(1); j++)
                {
                    Console.Write(sums[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
   
}
