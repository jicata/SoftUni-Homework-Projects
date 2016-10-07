using System;
using System.Collections.Generic;
using System.Linq;

class ZeroSubset
{
    static void Main()
    {
        int number;
        int[] Numbers = new int[5];
        bool result = false;
        for (int i = 0;i <=4; i++)
        {
            here: ;
            Console.WriteLine("Input number {0}", i + 1);
            if (int.TryParse(Console.ReadLine(), out number))
            {
                Numbers[i] = number;
            }
            else
            {
                goto here;
            }
        }

        if (Numbers[0] == 0 && Numbers[1] == 0 && Numbers[2] == 0 && Numbers[3] == 0 && Numbers[4] == 0)
        {
            result = true;
            Console.WriteLine(String.Join("+", Numbers) + " = 0");
            return;
        }

        for (int firstNum = 0; firstNum <= 3; firstNum++)
        {
            for (int secondNum = firstNum + 1; secondNum <= 4; secondNum++)
            {
                if (Numbers[firstNum] + Numbers[secondNum] == 0)
                {
                    result = true;
                    Console.WriteLine("{0} + {1} = 0", Numbers[firstNum], Numbers[secondNum]);
                }
            }
        }

         for (int firstNum = 0; firstNum <= 2; firstNum++)
         {
            for (int secondNum = firstNum + 1; secondNum <= 3; secondNum++)
            {
                for (int thirdNum = secondNum + 1; thirdNum <= 4; thirdNum++)
                {
                    if (Numbers[firstNum] + Numbers[secondNum] + Numbers[thirdNum]== 0)
                    {
                        result = true;
                        Console.WriteLine("{0} + {1} + {2} = 0", Numbers[firstNum], Numbers[secondNum], Numbers[thirdNum]);
                    }
                }
            }
        }

        for (int firstNum = 0; firstNum <= 1; firstNum++)
        {
            for (int secondNum = firstNum + 1; secondNum <= 2; secondNum++)
            {
                for (int thirdNum = secondNum + 1; thirdNum <= 3; thirdNum++)
                {
                    for (int fourthNum = thirdNum + 1; fourthNum <= 4; fourthNum++)
                    {
                        if (Numbers[firstNum] + Numbers[secondNum] + Numbers[thirdNum] + Numbers[fourthNum]== 0)
                        {
                            result = true;
                            Console.WriteLine("{0} + {1} + {2} + {3} = 0", Numbers[firstNum], Numbers[secondNum]
                                    , Numbers[thirdNum], Numbers[fourthNum]);
                        }
                    }
                }
            }
        }

        if (Numbers.Sum() == 0)
        {
            result = true;
            Console.WriteLine(String.Join("+", Numbers) + " = 0");
        }

        if (result == false)
        {
            Console.WriteLine("no zero subsets");
        }
    }
}