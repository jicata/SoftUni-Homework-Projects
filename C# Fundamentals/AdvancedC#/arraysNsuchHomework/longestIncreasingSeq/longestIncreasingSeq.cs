using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace longestIncreasingSeq
{
    class longestIncreasingSeq
    {
        static void Main()
        {
            string userInput = Console.ReadLine();
            string[] userArr = userInput.Split();
            
           
            List<int> sequences = new List<int>();
            List<int> longestSeq = new List<int>();

            
            int biggestCounter = 0;
            int current = 0;
            bool increase = false;


            int[] numbers = userArr.Select(x => int.Parse(x)).ToArray();
            int counter = 0;
            sequences.Add(numbers[current]);
            for (int i = 1; i < numbers.Length; i++)
            {
               
                    increase = false;
                    if (numbers[current] < numbers[i])
                    {
                        counter++;
                        increase = true;
                        sequences.Add(numbers[i]);
                        current = i;
                    }
                    if (increase == false || i == numbers.Length-1)
                    {
                        if (counter > biggestCounter)
                        {
                            longestSeq.Clear();
                            longestSeq = new List<int>(sequences);
                            biggestCounter = counter;
                        }
                        
                        counter = 0;

                        for (int j = 0; j < sequences.Count; j++)
                        {
                            Console.Write("{0} ", sequences[j]);
                        }
                        sequences.Clear();
                        current += 1;
                        if (i != numbers.Length-1)
                        {
                            sequences.Add(numbers[current]);
                        }
                        
                       
                        Console.WriteLine();
                
                
                }
            }
            Console.Write("Longest: ");
            for (int i = 0; i < longestSeq.Count ; i++)
            {
                
                Console.Write("{0} ", longestSeq[i]);
            }
            Console.WriteLine();
            
            

        }
    }
}
