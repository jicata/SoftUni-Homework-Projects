namespace _03_LongestSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        public static void Main()
        {
            //12 2 7 4 3 3 8
            string input = Console.ReadLine();
            List<int> numbers = input.Split().Select(x => int.Parse(x)).ToList();
            List<int> longestSeq = new List<int>();
            int maxLength = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                bool outOfRange = i != numbers.Count - 1;
                if (outOfRange && numbers[i] == numbers[i + 1])
                {
                    int count = 2;

                    for (int j = i+1; j < numbers.Count; j++)
                    {
                        bool outOfRangeJ = j != numbers.Count - 1;

                        if (outOfRangeJ)
                        {
                            if (numbers[j] == numbers[j + 1])
                            {
                                count++;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    if (count > maxLength)
                    {
                        longestSeq.Clear();
                        for (int k = 0; k < count; k++)
                        {
                            longestSeq.Add(numbers[i]);
                        }
                        maxLength = count;
                    }
                }
            }
            if (!longestSeq.Any())
            {
                Console.WriteLine(numbers[0]);
            }
            else
            {
                Console.WriteLine(string.Join(", ", longestSeq));
            }
            
        }
    }
}
