namespace _01_RecursivePermutations
{
    using System;
    using System.Linq;
    using System.Security.Cryptography;

    class Program
    {
        public static int numberOfPermutations = 0;
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = Enumerable.Range(1, n).ToArray();

            Permutate(array);
            Console.WriteLine("Total permutations: {0}", numberOfPermutations);
        }

        public static void Permutate(int[] array, int startIndex = 0)
        {
            if (startIndex >= array.Length - 1)
            {
                Console.WriteLine(string.Join(", ", array));
                numberOfPermutations++;
            }
            else
            {
                for (int i = startIndex; i < array.Length; i++)
                {
                    Swap(ref array[startIndex], ref array[i]);
                    Permutate(array, startIndex+1);
                    Swap(ref array[startIndex], ref array[i]);
                }
            }
        }

        private static void Swap(ref int i, ref int j)
        {
            if (i == j)
            {
                return;
            }
            i ^= j;
            j ^= i;
            i ^= j;
        }
    }
}
