namespace _03_LongestZigZagSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int[] zigZaggers = Console.ReadLine().Split().Select(int.Parse).ToArray();//new[] {8, 3, 5, 7, 0, 8, 9, 10, 20, 20, 20, 12, 19, 11};
            int[] longestZigZag = LongestZigZagSequence(zigZaggers);
            System.Console.WriteLine(string.Join(" ", longestZigZag));
        }

        public static int[] LongestZigZagSequence(int[] collection)
        {
            int[] len = new int[collection.Length];
            int[] prev = new int[collection.Length];

            int maxLenght = 0;
            int lastIndex = -1;

            for (int i = 0; i < collection.Length; i++)
            {
                int currentNumber = collection[i];
                len[i] = 1;
                prev[i] = -1;
                for (int j = 0; j < i; j++)
                {
                    int previousNumber = collection[j];
                    int previousNumberLength = len[j];
                    int currenNumberLength = len[i];

                    if (prev[j] != -1)
                    {
                        if (collection[prev[j]] > previousNumber && currentNumber > previousNumber &&
                            previousNumberLength + 1 > currenNumberLength)
                        {
                            len[i] = previousNumberLength + 1;
                            prev[i] = j;
                        }
                        else if (collection[prev[j]] < previousNumber && currentNumber < previousNumber &&
                                 previousNumberLength + 1 > currenNumberLength)
                        {
                            len[i] = previousNumberLength + 1;
                            prev[i] = j;
                        }
                    }
                    else
                    {
                        len[i] = 2;
                        prev[i] = j;
                    }
                }
                if (len[i] > maxLenght)
                {
                    maxLenght = len[i];
                    lastIndex = i;
                }

            }
            var longestSeq = new List<int>();
            while (lastIndex != -1)
            {
                longestSeq.Add(collection[lastIndex]);
                lastIndex = prev[lastIndex];
            }
            longestSeq.Reverse();
            return longestSeq.ToArray();

        }
    }
}
