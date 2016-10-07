using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selectionSortAlgorithm
{
    class selectionSort
    {
        static void Main()
        {
            string rawInput = Console.ReadLine();
            string[] rawInputStr = rawInput.Split();
            int[] numbers = rawInputStr.Select(x => int.Parse(x)).ToArray();
            int minimum = 0;
            int swap = 0;

            for (int i = 0; i < numbers.Length-1; i++)
            {
                minimum = i;
                for (int j = i+1; j < numbers.Length - 1; j++)
                {
                    if (numbers[j] < numbers[minimum])
                    {
                        minimum = j;
                        

                    }
                }
                if (minimum != i)
                {
                    swap = numbers[i];
                    numbers[i] = numbers[minimum];
                    numbers[minimum] = swap;
                }

               
            }
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
