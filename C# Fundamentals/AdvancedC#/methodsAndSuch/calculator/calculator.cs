using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    class calculator
    {
        static void Main()
        {
            int[] hui = { 1, 2, 3, 4, 5, 6, 7, 8 };
            Console.WriteLine(MinCalc(hui));
        }
    public static double MinCalc(double[] arrayOfNumbers)
    {
        double min = int.MaxValue;

        for (int i = 0; i < arrayOfNumbers.Length; i++)
        {
            if (arrayOfNumbers[i] < min)
            {
                min = arrayOfNumbers[i];
            }
        }
        return min;
    }
    public static int MinCalc(int[] arrayOfNumbers)
    {
        int min = int.MaxValue;

        for (int i = 0; i < arrayOfNumbers.Length; i++)
        {
            if (arrayOfNumbers[i] < min)
            {
                min = arrayOfNumbers[i];
            }
        }
        return min;
    }
    public static int MaxCalc(int[] arrayOfNumbers)
    {
        int max = int.MinValue;
        for (int i = 0; i < arrayOfNumbers.Length; i++)
        {

            if (arrayOfNumbers[i] > max)
            {
                max = arrayOfNumbers[i];
            }
        }
        return max;
    }
    public static int AvgCalc(int[] arrayOfNumbers)
    {
        int avg = 0;
        for (int i = 0; i < arrayOfNumbers.Length; i++)
        {
            avg += arrayOfNumbers[i];
        }
        avg = avg / arrayOfNumbers.Length;
        return avg;
    }
    public static int SumCalc(int[] arrayOfNumbers)
    {
        int sum = 0;
        for (int i = 0; i < arrayOfNumbers.Length; i++)
        {
            sum += arrayOfNumbers[i];
   
        }
        return sum;
    }
    public static int PrdctCalculator(int[] arrayOfNumbers)
    {
        int product = 1;
        for (int i = 0; i < arrayOfNumbers.Length; i++)
        {
            product *= arrayOfNumbers[i];
        }

        return product;

    }
    }
}
