namespace _01_SumAndAverage
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            string initialInput = Console.ReadLine();
            string[] input = new string[0];
            if (!string.IsNullOrEmpty(initialInput))
            {
                input = initialInput.Split();
            }

            List<int> numbers = new List<int>();

            
            for (int i = 0; i < input.Length; i++)
            {
                numbers.Add(int.Parse(input[i]));
            }

            int sum = 0;
            double average = 0;
            if (numbers.Count > 0)
            {
                foreach (int number in numbers)
                {
                    sum += number;
                }
                average = sum / (double)numbers.Count;
            }

            Console.WriteLine("Sum = " + sum);
            Console.WriteLine("Average = " + average);
        }
    }
}
