namespace _05_SumWithLimitedCoinsSubsetSum
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int targetSum = int.Parse(Console.ReadLine());
            int[] coins = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[,] possibleSums = new int[coins.Length, targetSum + 1];

            possibleSums[0, 0] = 1;
            for (int i = 1; i <= targetSum; i++)
            {
                if (coins[0]%i == 0)
                {
                    possibleSums[0, i] = coins[0];
                }
            }
           
            int lastDifferentCoinRow = 0;
            for (int coin = 1; coin < coins.Length; coin++)
            {
                int currentCoin = coins[coin];
                if (coins[coin-1] != currentCoin)
                {
                    lastDifferentCoinRow = coin - 1;
                }
                for (int sum = 0; sum <= targetSum; sum++)
                {
                    if (sum >= currentCoin)
                    {
                        possibleSums[coin, sum] = possibleSums[lastDifferentCoinRow, sum] + possibleSums[coin-1, sum - coins[coin]];
                    }
                    else
                    {
                        possibleSums[coin, sum] = possibleSums[coin - 1, sum];
                    }
                }
            }
            Console.WriteLine(possibleSums[coins.Length-1, targetSum]);
            
        }
        private static void PrintMatrix(int[,] possibleSums)
        {
            Console.WriteLine("0 1 2 3 4 5 6");
            for (int i = 0; i < possibleSums.GetLength(0); i++)
            {
                for (int j = 0; j < possibleSums.GetLength(1); j++)
                {
                    Console.Write(possibleSums[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
