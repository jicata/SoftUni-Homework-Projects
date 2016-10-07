using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fillTheMa3x
{
    class fillTheMa3x
    {
        static void Main()
        {
            
            int userInput = int.Parse(Console.ReadLine());
            int[,] pudding = new int[userInput, userInput];
            int counter = 1;


            //first one
            for (int i = 0; i < userInput; i++)
            {
                for (int j = 0; j < userInput; j++)
                {
                    pudding[j, i] = counter;
                    counter++;

                }

            }
            for (int i = 0; i < userInput; i++)
            {
                for (int j = 0; j < userInput; j++)
                {
                    Console.Write(pudding[i, j]);
                }
                Console.WriteLine();
            }
            counter=1;
            Console.WriteLine();
           
                
            for (int i = 0; i < userInput; i++)
            {
                if (i == 0 || i %2 == 0)
                {
                    for (int j = 0; j < userInput; j++)
                    {
                        pudding[j, i] = counter;
                        counter++;

                    }
                }
                else
                {
                    for (int j = userInput -1 ; j >= 0; j--)
                    {
                        pudding[j, i] = counter;
                        counter++;
                                
                    }
                }
                        
            }
                
                
            for (int i = 0; i < userInput; i++)
             { 
                for (int j = 0; j < userInput; j++)
                {
                    Console.Write(pudding[i,j]);
                }
                Console.WriteLine();
             }
            
        }
    }
}
