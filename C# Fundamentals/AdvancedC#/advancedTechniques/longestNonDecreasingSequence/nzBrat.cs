using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace longestNonDecreasingSequence
{
    class LongestNonDecreasingSubsequence
    {
        static int numberOfLoops;
        static int countOfNumbers;
        static int[] loops;
        static int[] numbers;
        static int[] longestPositiveSequence = new int[0];

        static void Main()
        {
            Console.Write("Enter numbers:");
            string[] input = Console.ReadLine().Split();

            countOfNumbers = input.Length;
            numberOfLoops = countOfNumbers;
            numbers = new int[countOfNumbers];

            for (int index = 0; index < input.Length; index++)
            {
                numbers[index] = Convert.ToInt32(input[index]);
            }

            while (numberOfLoops > 0)
            {
                loops = new int[numberOfLoops];
                FindSubsets(0, 0);
                numberOfLoops--;
            }

            Console.WriteLine();
            foreach (var item in longestPositiveSequence)
            {
                Console.Write(item + " ");
            }
        }

        static void FindSubsets(int currentLoop, int lastNumber)
        {
            if (currentLoop == numberOfLoops)
            {
                CheckSequence();
                return;
            }

            for (int nextNumber = lastNumber; nextNumber < countOfNumbers; nextNumber++)
            {
                loops[currentLoop] = numbers[nextNumber];
                FindSubsets(currentLoop + 1, nextNumber + 1);
            }
        }

        private static void CheckSequence()
        {
            bool positiveSequence = true;

            for (int index = 0; index < loops.Length - 1; index++)
            {
                if (loops[index] > loops[index + 1])
                {
                    positiveSequence = false;
                    break;
                }
            }

            if (positiveSequence)
            {
                if (loops.Length > longestPositiveSequence.Length)
                {
                    longestPositiveSequence = new int[loops.Length];
                    for (int index = 0; index < loops.Length; index++)
                    {
                        longestPositiveSequence[index] = loops[index];
                    }
                }
            }
        }
    }
}
