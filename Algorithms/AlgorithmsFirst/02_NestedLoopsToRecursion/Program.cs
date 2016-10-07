namespace _02_NestedLoopsToRecursion
{
    using System;

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] vector = new int[n];
            RecursivePermutationPrint(0,n, vector);
        }

        private static void RecursivePermutationPrint(int index, int n, int[] vector)
        {
            if (index >= n)
            {
                Print(vector);
                return;
            }
            for (int i = 1; i <= n; i++)
            {
                vector[index] = i;
                RecursivePermutationPrint(index+1, n, vector);
            }
        }

        private static void Print(int[] vector)
        {
            Console.WriteLine(string.Join(", ", vector));

        }
    }
}
