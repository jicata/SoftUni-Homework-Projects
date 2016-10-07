namespace _01_ReversedArray
{
    using System;

    class Program
    {
        static void Main()
        {
            int[] littleBlackArray = new[] {1, 2, 3, 4, 5, 6, 7, 8};
           
            
            int[] reversedArray = new int[littleBlackArray.Length];
            int count = 0;
            reversedArray= ReverseArray(reversedArray,littleBlackArray, littleBlackArray.Length - 1, count);
            Console.WriteLine(String.Join(", ", reversedArray));
        }

        private static int[] ReverseArray(int[] targetCollection, int[] sourceCollection, int sourceIndex,
            int targetIndex)
        {
            if (sourceIndex < 0)
            {
                return targetCollection;
            }
            targetCollection[targetIndex] = sourceCollection[sourceIndex];
            return ReverseArray(targetCollection, sourceCollection, sourceIndex - 1, targetIndex + 1);
        }

        
    }
}
