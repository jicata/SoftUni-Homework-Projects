using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithmsComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10000000;
            long[] insertArray = new long[n];
            long[] selectArray = new long[n];
            long[] mergedArray = new long[n];
            long[] quickArray = new long[n];

            Random rnd = new Random();

            for (int i = 0; i < insertArray.Length; i++)
            {
                long number = rnd.Next();
                insertArray[i] = number;
                selectArray[i] = number;
                mergedArray[i] = number;
                quickArray[i] = number;
            }
            System.Diagnostics.Stopwatch stopwatch = new Stopwatch();

            //stopwatch.Start();
            //InsertionSort(insertArray);
            //stopwatch.Stop();
            //Console.WriteLine("Insertion sort: " + stopwatch.Elapsed.TotalMilliseconds);

            //stopwatch.Restart();
            //SelectionSort(selectArray);
            //stopwatch.Stop();
            //Console.WriteLine("Selection sort: " + stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            MergeSort(mergedArray);
            stopwatch.Stop();
            Console.WriteLine("Merge sort: " + stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            QuickSort(quickArray);
            stopwatch.Stop();
            Console.WriteLine("Quick sort: "+ stopwatch.Elapsed.TotalMilliseconds);
            //Console.WriteLine(string.Join(", ", quickArray));



        }

        private static void Swap(ref long valOne, ref long valTwo)
        {
            valOne = valOne + valTwo;
            valTwo = valOne - valTwo;
            valOne = valOne - valTwo;
        }

        private static void SwapWithTemp(ref long valOne, ref long valTwo)
        {
            long temp = valOne;
            valOne = valTwo;
            valTwo = temp;
        }

        private static void SelectionSort(long[] inputArray)
        {
            long index_of_min = 0;
            for (int iterator = 0; iterator < inputArray.Length - 1; iterator++)
            {
                index_of_min = iterator;
                for (int index = iterator + 1; index < inputArray.Length; index++)
                {
                    if (inputArray[index] < inputArray[index_of_min])
                        index_of_min = index;
                }
                Swap(ref inputArray[iterator], ref inputArray[index_of_min]);
            }
        }

        private static void InsertionSort(long[] inputArray)
        {
            long j = 0;
            long temp = 0;
            for (int index = 1; index < inputArray.Length; index++)
            {
                j = index;
                temp = inputArray[index];
                while ((j > 0) && (inputArray[j - 1] > temp))
                {
                    inputArray[j] = inputArray[j - 1];
                    j = j - 1;
                }
                inputArray[j] = temp;
            }
        }
        private static void MergeSort(long[] inputArray)
        {
            int left = 0;
            int right = inputArray.Length - 1;
            InternalMergeSort(inputArray, left, right);
        }

        private static void InternalMergeSort(long[] inputArray, int left, int right)
        {
            int mid = 0;
            if (left < right)
            {
                mid = (left + right) / 2;
                InternalMergeSort(inputArray, left, mid);
                InternalMergeSort(inputArray, (mid + 1), right);
                MergeSortedArray(inputArray, left, mid, right);
            }
        }

        private static void MergeSortedArray(long[] inputArray, int left, int mid, int right)
        {
            int index = 0;
            int total_elements = right - left + 1; //BODMAS rule
            int right_start = mid + 1;
            int temp_location = left;
            long[] tempArray = new long[total_elements];

            while ((left <= mid) && right_start <= right)
            {
                if (inputArray[left] <= inputArray[right_start])
                {
                    tempArray[index++] = inputArray[left++];
                }
                else
                {
                    tempArray[index++] = inputArray[right_start++];
                }
            }
            if (left > mid)
            {
                for (int j = right_start; j <= right; j++)
                    tempArray[index++] = inputArray[right_start++];
            }
            else
            {
                for (int j = left; j <= mid; j++)
                    tempArray[index++] = inputArray[left++];
            }
            //Array.Copy(tempArray, 0, inputArray, temp_location, total_elements);
            // just another way of accomplishing things (in-built copy)
            for (int i = 0, j = temp_location; i < total_elements; i++, j++)
            {
                inputArray[j] = tempArray[i];
            }
        }
        static void QuickSort(long[] a)
        {
            QuickSortRecursive(a, 0, a.Length);
        }

        static void swap(long[] arr, int m, int n)
        {
            long tmp = arr[m];
            arr[m] = arr[n];
            arr[n] = tmp;
        }

        static void QuickSortRecursive(long[] a, int low, int high)
        {
            if (high - low <= 1) return;
            long pivot = a[high - 1];
            int split = low;
            for (int i = low; i < high - 1; i++)
            {
                if (a[i] < pivot)
                {
                    swap(a, i, split++);
                }
            }

            swap(a, high - 1, split);
            QuickSortRecursive(a, low, split);
            QuickSortRecursive(a, split + 1, high);
            return;
        }
    }
}
