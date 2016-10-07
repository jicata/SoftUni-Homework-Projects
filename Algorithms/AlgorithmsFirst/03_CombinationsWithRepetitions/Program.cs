namespace _03_CombinationsWithRepetitions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static int[] numbers;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            numbers = new int[k];
            SimulateNestedLoops(k, n);
        }

        static void SimulateNestedLoops(int numberOfNestedLoops, int originalNumber, int start = 1)
        {
            if (numberOfNestedLoops == 0)
            {
                PrintNumbers();
                return;
            }

            for (int i = start; i <= originalNumber; i++)
            {
                numbers[numbers.Length - numberOfNestedLoops] = i;
                SimulateNestedLoops(numberOfNestedLoops - 1, originalNumber, i);
            }
        }

        private static void PrintNumbers()
        {
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
