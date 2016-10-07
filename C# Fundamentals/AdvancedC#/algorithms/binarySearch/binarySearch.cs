using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binarySearch
{
    class binarySearch
    {
        static void Main()
        {
            int[] sortedArray = {-2 ,0, 3, 5, 213, 8582, 239191, 985128};
            int didWeFindIt = LinearSearch(sortedArray, 213);
            Console.WriteLine(didWeFindIt);
            didWeFindIt = BinarySearch(sortedArray, -12736);
            //Console.WriteLine(didWeFindIt);
        }
        public static int BinarySearch(int[] sortedArray, int element)
        {
            int foundIt = 0;
            double min = 0;
            double max = sortedArray.Length - 1;
            while (foundIt != element && foundIt !=-1)
            {
                if (sortedArray[(int)Math.Ceiling(min+max/2)] < element)
                {
                    min = (int)Math.Floor(min + max / 2);
                    
                }
                else if(sortedArray[(int)Math.Ceiling(min+max/2)] > element)
                {
                    max = (int)Math.Floor(min + max / 2);
                    
                }
                else
                {
                    foundIt = element;
                }
                if(max - min >1)
                {
                    for (int i = (int)min; i < (int)max; i++)
                    {
                        if (sortedArray[i] == element)
                        {
                            foundIt = element;
                        }
                       
                    }
                }
                else
                {
                    foundIt = -1;
                }
               
            }
            return foundIt;
        }
        public static int LinearSearch(int[] sortedArray, int element)
        {
            bool found = false;
            for (int i = 0; i < sortedArray.Length; i++)
            {
                
                if (element == sortedArray[i])
                {
                    found = true;
                    break;

                }
                else
                {
                    found = false;
                }
            }
            if (found)
            {
                return element;
            }
            else
            {
                return -1;
            }
            
        }
    }
}
