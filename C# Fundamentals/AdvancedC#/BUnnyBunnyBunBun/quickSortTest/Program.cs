namespace quickSortTest
{
    using System;
    using System.Collections.Concurrent;
    using System.Diagnostics;

    class Program
    {
        static void Main()
        {
            Random rng = new Random();
            
            int[] unsortedArray = new[] { 2, 54, 123, 423, 6, 1, 2, 3, 1231, 5,
                2, 32, 1, 23, 12, 31, 312, 31, 24, 1, 3543, 5, 346, 634, 5, 423,
                41, 31, 23, 1234, 4, 123, 5345, 1, 23, 1243, 134, 35, 3463 };
            int[] randomlySortedArray = new int[100000];
            for (int i = 0; i < 100000; i++)
            {
                rng = new Random(i%68*56);
                randomlySortedArray[i] = rng.Next(0,100);

            }
            Stopwatch sw = new Stopwatch();
            sw.Start();
            QuickSort(randomlySortedArray, 0, randomlySortedArray.Length - 1);
            sw.Stop();
            
            Console.WriteLine(string.Join(", ", randomlySortedArray));
            Console.WriteLine(sw.Elapsed);
        }

        public static void QuickSort<T>(T[] array, int startIndex, int endIndex)
            where T : IComparable
        {
            if (startIndex < endIndex)
            {
                int partitionIndex = Partition<T>(array, startIndex, endIndex);
                QuickSort<T>(array, startIndex, partitionIndex - 1);
                QuickSort<T>(array, partitionIndex + 1, endIndex);
            }
        }

        private static int Partition<T>(T[] array, int startIndex, int endIndex)
            where T : IComparable
        {
            T pivot = array[endIndex];
            int partitionIndex = startIndex;
            for (int currentIndex = startIndex; currentIndex < endIndex; currentIndex++)
            {
                if (array[currentIndex].CompareTo(pivot) < 0)
                {
                    Swap(array, partitionIndex, currentIndex);
                    partitionIndex++;
                }
            }
            Swap(array, partitionIndex, endIndex);
            return partitionIndex;
        }

        private static void Swap<T>(T[] array, int partitionIndex, int secondIndex)
            where T : IComparable
        {
            T temp = array[partitionIndex];
            array[partitionIndex] = array[secondIndex];
            array[secondIndex] = temp;
        }
    }
}
