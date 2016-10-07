using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstLargerThanNeighbours
{
    class Program
    {
        static void Main()
        {
            int[] sequnce = { 1, 3, 4, 5, 1, 0, 5 };
            int[] sequenceTwo = { 1, 2, 3, 4, 5, 6, 6 };
            int[] sequenceThree = { 1, 1, 1 };
            Console.WriteLine(IsFirstLarger(sequnce));
            Console.WriteLine(IsFirstLarger(sequenceTwo));
            Console.WriteLine(IsFirstLarger(sequenceThree));

        }
        public static int IsFirstLarger(int[] aSequenceOfNumbers)
        {
            int theNumber = 0;
            bool larger = false;
            for (int i = 0; i < aSequenceOfNumbers.Length; i++)
            {
                if(i==0)
                {
                    if (aSequenceOfNumbers[i] > aSequenceOfNumbers[i+1])
                    {
                        theNumber = aSequenceOfNumbers[i];
                        larger = true;
                        
                        return theNumber;
                        
                    }

                }
                else if(i == aSequenceOfNumbers.Length -1)
                {
                    if(aSequenceOfNumbers[i] > aSequenceOfNumbers[i-1])
                    {
                        theNumber = aSequenceOfNumbers[i];
                        larger = true;
                        return theNumber;
                    }
                }
                else if (i!=0 && i!= aSequenceOfNumbers.Length-1)
                {
                    if (aSequenceOfNumbers[i] > aSequenceOfNumbers[i-1] && aSequenceOfNumbers[i] > aSequenceOfNumbers[i+1])
                    {
                        theNumber = aSequenceOfNumbers[i];
                        larger = true;
                        return theNumber;
                    }
                }
                
                
            }
            if (!larger)
            {
                theNumber = -1;
                
            }
            return theNumber;
            
            

        }
        
    }
}
