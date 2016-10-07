using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arraysAndShit
{
    class bubbleSortOptimised
    {
        static void Main(string[] args)
        {
            string initialInput = Console.ReadLine();
            string[] strArr = initialInput.Split();
            int[] intArr = strArr.Select(x => int.Parse(x)).ToArray();
            int bigger = 0;
            int smaller = 0;
            int counter = 0;
            bool flag = false;

            do
            {
                flag = false;
                for (int j = 0; j < intArr.Length; j++)
                {
                    for (int i = 0; i < intArr.Length; i++)
                    {
                        if (i + 1 < intArr.Length)
                        {
                            if (intArr[i + 1] < intArr[i])
                            {
                                flag = true;
                                bigger = intArr[i + 1];

                                intArr[i + 1] = intArr[i];
                                intArr[i] = bigger;
                                counter++;
                            }
                        }
                    }


                }
            }
            while (flag);



            Console.WriteLine(counter);
                Console.Write(string.Join(", ", intArr));
                Console.WriteLine();

        }
    }
}
