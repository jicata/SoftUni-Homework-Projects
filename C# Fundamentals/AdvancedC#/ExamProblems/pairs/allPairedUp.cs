using System;


namespace pairs
{
    class allPairedUp
    {
        static void Main()
        {
            string[] incomingNumbers = Console.ReadLine().Split(' ');
            int[] numbers = Array.ConvertAll(incomingNumbers, int.Parse);

            int firstNum = numbers[0];
            int secondNum = numbers[1];
            int prevValue = firstNum + secondNum;
            int maxDiff = 0;

            for (int i = 2; i < numbers.Length -1; i+=2)
            {
                firstNum = numbers[i];
                secondNum = numbers[i + 1];
                int lastValue = firstNum + secondNum;
                int diff = Math.Abs(prevValue - lastValue);
                maxDiff = Math.Max(diff, maxDiff);
                prevValue = lastValue;

            }
            if (maxDiff == 0)
            {
                Console.WriteLine("Yes, sum={0}", prevValue);
            }
            else
            {
                Console.WriteLine("No, maxdiff={0}", maxDiff);
            }

        }
    }
}
