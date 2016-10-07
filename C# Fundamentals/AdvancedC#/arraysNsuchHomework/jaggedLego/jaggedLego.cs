using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jaggedLego
{
    class jaggedLego
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[][] firstArray = new int[n][];
            int[][] secondArray = new int[n][];
            //string[][] firstArray = new string[n][];
            //string[][] secondArray = new string[n][];
            int counter = 0;
            int index = 0;
            bool same = false;
            int size = 0;
            long firstSize =0;
            long secondSize = 0;
            long totalSize = 0;

            for (int i = 0; i < n; i++)
            {
                string rawUser = Console.ReadLine();
                if (string.IsNullOrEmpty(rawUser))
                {
                    rawUser = "0";
                }
                int[] userInput = rawUser.Trim().Split().Select(x => int.Parse(x)).ToArray();
                firstArray[i] = userInput;
                
            }
            for (int i = 0; i < n; i++)
            {
                string rawMeat = Console.ReadLine();
                if (string.IsNullOrEmpty(rawMeat))
                {
                    rawMeat = "0";
                }
                int[] moreUserInput = rawMeat.Trim().Split().Select(x => int.Parse(x)).ToArray();

                secondArray[i] = moreUserInput;
            }

            for (int i = 1; i < n; i++)
            {
                size = firstArray[0].GetLength(0) + secondArray[0].GetLength(0);
                if (firstArray[i].GetLength(0) + secondArray[i].GetLength(0) == size)
                {
                    same = true;
                    index++;
                }
                else
                {
                    same = false;
                    index--;
                    for (int p = 0; p < n; p++)
                    {
                        firstSize += firstArray[p].GetLength(0);
                        secondSize += secondArray[p].GetLength(0);

                    }
                    totalSize = firstSize + secondSize;
                    Console.WriteLine("The total number of cells is: {0}", totalSize);
                    break;
                }
               
            }
            if (same = true && index == n-1)
            {

                
                for (int i = 0; i < n; i++)
                {
                    Array.Reverse(secondArray[i]);
                }
                int[,] tukaGiSlagam = new int[n, size];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < firstArray[i].GetLength(0); j++)
                    {
                        tukaGiSlagam[i, j] = firstArray[i][j];
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    for (int j = firstArray[i].GetLength(0); j < size; j++)
                    {

                        tukaGiSlagam[i, j] = secondArray[i][counter];
                        counter++;
                    }
                    counter = 0;
                }
                for (int i = 0; i < n; i++)
                {
                    
                    for (int j = 0; j < size; j++)
                    {
                        if (j==0)
                        {
                            Console.Write("[{0}, ",tukaGiSlagam[i,j] );
                        }
                        else if (j == size - 1)
                        {
                            Console.Write("{0}]", tukaGiSlagam[i,j]);
                        }
                        else
                        {
                            Console.Write("{0}, ", tukaGiSlagam[i, j]);
                        }
                        
                    }
                   
                    Console.WriteLine();

                }
            }
            
            
            


            
        }
    }
}
