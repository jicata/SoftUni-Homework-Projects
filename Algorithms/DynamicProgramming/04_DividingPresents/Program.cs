namespace _04_DividingPresents
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Xml.Schema;

    class Program
    {
        static void Main()
        {
            int[] presents = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            int totalValue = presents.Sum();
            int median = totalValue / 2;
            var possibleSums = CalculatePossibleSumsOptimized(presents);
            var bestSubset = RetrieveSubset(possibleSums, median);
            int alanValue = bestSubset.Sum();
            int bobValue = totalValue - alanValue;
            Console.WriteLine("Difference: {0}", Math.Abs(bobValue - alanValue));
            Console.WriteLine("Alan: {0} Bob: {1}", alanValue, bobValue);
            Console.WriteLine("Alan takes {0}",string.Join(" ", bestSubset));
            Console.WriteLine("Bob takes the rest.");
        }
        /// <summary>
        /// The "Meh" approach to the subset problem
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="targetSum"></param>
        /// <returns></returns>
        private static ICollection<int> CalculatePossibleSums(int[] numbers)
        {
            HashSet<int> possibleSums = new HashSet<int>() {0};          
            for (int i = 0; i < numbers.Length; i++)
            {
               
                HashSet<int> newSums = new HashSet<int>();
                foreach (var possibleSum in possibleSums)
                {
                    int newSum = numbers[i] + possibleSum;
                    newSums.Add(newSum);
                }
                possibleSums.UnionWith(newSums);
                
            }
            return possibleSums;
        }

        private static IDictionary<int, int> CalculatePossibleSumsOptimized(int[] numbers)
        {
            Dictionary<int, int> possibleSums = new Dictionary<int, int>();
            possibleSums.Add(0,0);
            for (int i = 0; i < numbers.Length; i++)
            {
                Dictionary<int,int> newSums = new Dictionary<int, int>();
                foreach (var sum in possibleSums.Keys)
                {
                    int newSum = sum + numbers[i];
                    if (!possibleSums.ContainsKey(newSum))
                    {
                        newSums.Add(newSum, numbers[i]);
                    }
                }
                foreach (var newSum in newSums)
                {
                    if (!possibleSums.ContainsKey(newSum.Key))
                    {
                        possibleSums.Add(newSum.Key, newSum.Value);
                    }                    
                }
            }
            return possibleSums;
        }

        private static IList<int> RetrieveSubset(IDictionary<int, int> possibleSums, int targetSum)
        {
            List<int> subset = new List<int>();
            while (!possibleSums.ContainsKey(targetSum))
            {
                targetSum--;
            }
            while (targetSum > 0)
            {
                int lastNum = possibleSums[targetSum];
                subset.Add(lastNum);
                targetSum -= lastNum;
            }
           // subset.Reverse();
            return subset;
        } 
    }
}
