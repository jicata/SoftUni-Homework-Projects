using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace insertionSort
{
    class insertIt
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            int temp = 0;
            for (int i = 1; i < numbers.Length; i++)
            {
               int j=i;
                  while (j>0 && (numbers[j] < numbers[j-1]))
                  {
                    temp = numbers[j];
                    numbers[j] = numbers[j-1];
                    numbers[j-1] = temp;
                    j = j - 1;
                       
                  }                        
                    
                    
                
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }// {1,3,2,4}
    //
}
