using System.Collections.Generic;
using System;

public class RemovedNumbers
{
    public static List<long[]> removNb(long n)
    {
        List<long[]> result = new List<long[]>();
        long totalSum = (n * (n + 1)) / 2;
        for (long currentNumber = n; currentNumber > 0; currentNumber--)
        {
            for (long secondNumber = n; secondNumber >= 1; secondNumber--)
            {
                long productOfTheTwo = currentNumber * secondNumber;
                long totalSumDiminished = totalSum - (secondNumber + currentNumber);
                if (productOfTheTwo < totalSumDiminished)
                {
                    break;
                }
                if (productOfTheTwo == totalSumDiminished && currentNumber != secondNumber)
                {
                    long[] ABRemoved = new long[2];
                    ABRemoved[1] = currentNumber;
                    ABRemoved[0] = secondNumber;
                    result.Add(ABRemoved);
                }
            }
        }
        return result;
    }
}