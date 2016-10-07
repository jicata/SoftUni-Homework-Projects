namespace _05_NumberOfOccurences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            Dictionary<int, int> occurences = new Dictionary<int, int>();

            int[] numbers = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i];
                if (!occurences.ContainsKey(currentNumber))
                {
                    occurences.Add(currentNumber,1);
                }
                else
                {
                    occurences[currentNumber]++;
                }
            }
            foreach (var number in occurences.OrderBy(x=>x.Key))
            {
                Console.WriteLine(number.Key + " -> " + number.Value + " times");
            }
        }
    }
}
