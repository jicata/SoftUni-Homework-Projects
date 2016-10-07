namespace Town
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] distances = new int[n];
            string[] cities = new string[n];
            for (int i = 0; i < n; i++)
            {
                string[] distanceAndCity = Console.ReadLine().Split();
                distances[i] = int.Parse(distanceAndCity[0]);
                cities[i] = distanceAndCity[1];
            }
            
            int[] increasingSequences = new int[n];
            int[] decreasingSequences = new int[n];

            int[] increasingPrev = new int[n];
            int[] decreasingPrev = new int[n];

            //increasingPrev[0] = -1;
            //increasingSequences[0] = 1;

            for (int i = 0; i < n; i++)
            {
                increasingSequences[i] = 1;
                increasingPrev[i] = -1;
                int currentDist = distances[i];
                for (int j = 0; j < i; j++)
                {
                    int previousDistance = distances[j];
                    int previousLength = increasingSequences[j];
                    int currentDistanceLength = increasingSequences[i];
                    if (previousDistance < currentDist && previousLength + 1 > currentDistanceLength)
                    {
                        increasingSequences[i] = increasingSequences[j] + 1;
                        increasingPrev[i] = j;
                    }
                }
            

            }
            //decreasingPrev[n-1] = -1;
           // decreasingSequences[n-1] = 1;

           
            for (int i = n-1; i >=0 ; i--)
            {
                decreasingSequences[i] = 1;
                decreasingPrev[i] = -1;
                int currentDist = distances[i];
                for (int j = i; j < n; j++)
                {
                    int previousDistance = distances[j];
                    int previousLength = decreasingSequences[j];
                    int currentDistanceLength = decreasingSequences[i];
                    if (currentDist > previousDistance && previousLength + 1 > currentDistanceLength)
                    {
                        decreasingSequences[i] = decreasingSequences[j] + 1;
                        decreasingPrev[i] = j;
                    }
                }
               
            }
           
            

            //Console.WriteLine(string.Join(" ", increasingSequences));
            //Console.WriteLine();
            //Console.WriteLine(string.Join(" ", decreasingSequences));
            int maxSum = 0;
            for (int i = 0; i < n; i++)
            {
                int currentSum = 0;
                currentSum = (increasingSequences[i] + decreasingSequences[i])-1;
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                }
            }

            Console.WriteLine(maxSum);
        }
    }
}
