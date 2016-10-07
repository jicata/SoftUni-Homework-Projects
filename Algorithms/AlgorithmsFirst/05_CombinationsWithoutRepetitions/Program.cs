namespace _05_CombinationsWithoutRepetitions
{
    using System;

    class Program
    {
        private static int[] numbers;

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            numbers = new int[k];
            SimulateNestedLoops(0,k, n,1);
        }

        static void SimulateNestedLoops(int index,int maxLength, int originalNumber, int start)
        {
            if (index >= maxLength)
            {
                PrintNumbers();
                return;
            }

            for (int i = start; i <= originalNumber; i++)
            {
                numbers[index] = i;
                SimulateNestedLoops(index+1,maxLength, originalNumber, i+1);
            }
        }

        private static void PrintNumbers()
        {
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
