using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sum_of_elements
{
    class sumOfElements
    {
        static void Main()
        {
            bool foundIt = false;
            string[] numericString = Console.ReadLine().Split();
            int[] mySequence = numericString.Select(int.Parse).ToArray();
            int sum = Math.Abs(mySequence.Sum() - mySequence.Max());
            int diff = Math.Abs(mySequence.Max() - sum); 
            for (int i=0; i<mySequence.Length; i++)
            {
                if (mySequence[i] == sum)
                {
                    Console.WriteLine("Yes, sum={0}", sum);
                    foundIt = true;
                    break;
                }
            }
            if (foundIt == false)
            {
                Console.WriteLine("No, diff={0}", diff);
            }
        }
    }
}
