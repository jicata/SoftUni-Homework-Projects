namespace _05_SumWithLimitedCoins
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

            possibleSums[0, 0] = 0;
            for (int i = 1; i <= targetSum; i++)
            {
                possibleSums[0, i] = coins[0];
            }
           
            int counter = 0;
            for (int coin = 1; coin < coins.Length; coin++)
            {
                int currentCoin = coins[coin];
                for (int sum = 0; sum <= targetSum; sum++)
                {
                    possibleSums[coin, sum] = possibleSums[coin - 1, sum];
                    int leftOver = sum - currentCoin;
                    if (leftOver >= 0)
                    {
                        if (possibleSums[coin - 1, leftOver] + currentCoin > possibleSums[coin, sum])
                        {
                            possibleSums[coin, sum] = possibleSums[coin-1,leftOver] + currentCoin;
                        }
                    }
                    if (possibleSums[coin, sum] == targetSum)
                    {
                        counter++;
                    }
                }
            }
            PrintMatrix(possibleSums);
            Console.WriteLine();
            Console.WriteLine(counter);
            //Console.WriteLine(possibleSums[coins.Length-1, targetSum]);
        }

        private static void PrintMatrix(int[,] possibleSums)
        {
            //Console.WriteLine("0 1 2 3 4 5 6");
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
