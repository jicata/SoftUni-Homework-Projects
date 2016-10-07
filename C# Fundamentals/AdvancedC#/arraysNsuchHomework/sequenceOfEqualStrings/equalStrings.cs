using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sequenceOfEqualStrings
{
    class equalStrings
    {
        static void Main()
        {
            string userInput = Console.ReadLine();
            string[] inputArr = userInput.Split();

            Console.Write(inputArr[0]);
            for (int i = 1; i < inputArr.Length ; i++)
            {
                if (inputArr[i] == inputArr[i-1])
                {
                    Console.Write(" " + inputArr[i]);
                }
                else
                {
                    Console.WriteLine();
                    Console.Write(inputArr[i]);
                     
                    
                }
                
    
                   
                
               
                
            }
            Console.WriteLine();

        }
    }
}
