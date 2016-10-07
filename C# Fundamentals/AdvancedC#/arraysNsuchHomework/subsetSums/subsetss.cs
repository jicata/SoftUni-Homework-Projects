using System;
using System.Collections.Generic;
using System.Linq;

namespace subsetsBro
{
    class subsetAmigo
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            double maxCombinations = Math.Pow(2, numbers.Length);
            bool matchFound = false;

            List<int> sums = new List<int>();
            List<List<int>> legitSums = new List<List<int>>();

            for (int i = 0; i < maxCombinations; i++)
            {
                int sum = 0;
                int pos = numbers.Length;
                for (int j = 0; j < numbers.Length; j++)
                {
                    int bitmask = i & (1 << j);
                    pos--;
                    if (bitmask != 0)
                    {
                        sum += numbers[pos];
                        sums.Add(numbers[pos]);

                    }

                }
                if (sum == n)
                {
                    legitSums.Add(sums);
                    matchFound = true;
                }
                sums = new List<int>();

            }
            if (!matchFound)
            {
                Console.WriteLine("No such subsets!");
            }
            else
            {
                List<List<int>> finalDeal = new List<List<int>>(legitSums.OrderBy(l => l.Count));
                for (int i = 0; i < finalDeal.Count - 1; i++)
                {
                    int first = finalDeal[i].First();
                    for (int j = i + 1; j < finalDeal.Count; j++)
                    {
                        int second = finalDeal[j].First();
                        if (finalDeal[i].Count == finalDeal[j].Count && second > first)
                        {
                            List<int> temp = finalDeal[i];
                            finalDeal[i] = finalDeal[j];
                            finalDeal[j] = temp;
                        }
                    }
                }
                foreach (var item in finalDeal)
                {
                    foreach (var parche in item)
                    {
                        Console.Write(parche + "+");
                    }
                    Console.Write("\b = {0}", n);
                    Console.WriteLine();
                }
            }



        }
        static void Print(List<int> nums, int sum)
        {

            foreach (var item in nums)
            {
                Console.Write(item + " + ");
            }
            Console.WriteLine("\b\b\b = " + sum);
        }



    }
}