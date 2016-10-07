using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieveIT
{
    class sieve
    {
        static void Main()
        {
            int userInput = int.Parse(Console.ReadLine());
            List<int> numberList = new List<int>();
            bool[] boolArray = new bool[userInput];
            numberList.Add(2);
            int count = 0;
            for (int i = 0; i < boolArray.Length; i++)
            {
                boolArray[i] = true;
            }
            SieveofEratosthenes(boolArray, userInput);

            //for (int i = 3; i < boolArray.Length; i++)
            //{
            //    if(boolArray[i] == true)
            //    {
            //        numberList.Add(i);
            //    }
                
            //}
            AddSievedPrimesToList(boolArray, numberList);
            Console.WriteLine(string.Join(", ", numberList));
            
        }
        public static bool[] SieveofEratosthenes(bool[] boolArray, int userInput)
        {
            for (int i = 2; i < userInput; i++)
            {
                if (boolArray[i] == true)
                {
                    for (int j = 2; (j * i) < userInput; j++)
                    {
                        boolArray[i * j] = false;
                    }
                }
            }
            return boolArray;
        }
        public static List<int> AddSievedPrimesToList(bool[] sievedNumbers, List<int> numberList)
        {
            for (int i = 3; i < sievedNumbers.Length; i++)
            {
                if (sievedNumbers[i] == true)
                {
                    numberList.Add(i);
                }

            }
            return numberList;

        }

    }
}
