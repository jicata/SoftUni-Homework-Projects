using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sortArray
{
    class sortArray
    {
        static void Main()
        {
            string userInput = Console.ReadLine();
            string[] strArr = userInput.Split();
            int[] numbers = strArr.Select(x => int.Parse(x)).ToArray();
            //int[] intArr = strArr.Select(x => int.Parse(x)).ToArray();
            int bigger = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (j + 1 < numbers.Length)
                    {
                        if (numbers[j] > numbers[j+1])
                        {
                            bigger = numbers[j];
                            numbers[j] = numbers[j + 1];
                            numbers[j + 1] = bigger;

                        }
                    }
                }
            }
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
