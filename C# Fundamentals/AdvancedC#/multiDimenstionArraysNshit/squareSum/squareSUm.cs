using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace squareSum
{
    class squareSUm
    {
        static void Main()
        {
            string[] rawInput = Console.ReadLine().Split();
            int[] userInput = rawInput.Select(x=>int.Parse(x)).ToArray();
            int row = userInput[0];
            int col = userInput[1];
            int maxSum = int.MinValue;
            int[,] matrix = new int[row, col];
            int currentRow = 0;
            int currentCol = 0;
            // Fill up the ma3x!
            for (int i = 0; i < row; i++)
            {
                int[] moreInput = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = moreInput[j];
                }
                
            }

            //Get the 3x3 Max Platform rolling
            for (int i = 0; i < row - 2; i++)
            {
                for (int j = 0; j < col -2 ; j++)
                {
                    int sum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2] + 
                        matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2] +
                        matrix[i+2,j] + matrix[i+2, j+1] + matrix[i+2,j+2];
                    if (sum> maxSum)
                    {
                        maxSum = sum;
                        currentRow = i;
                        currentCol = j;
                    }
                }
            }
            Console.WriteLine("Sum = {0}",maxSum);

            //Print the Max Platform
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("[{0}] ",matrix[currentRow + i, currentCol + j]);
 
                }
                Console.WriteLine();
            }

            // optional : print entire matrix
            //for (int i = 0; i < row; i++)
            //{
            //    for (int j = 0; j < col; j++)
            //    {
            //        Console.Write(matrix[i, j]);

            //    }
            //    Console.WriteLine();
            //}
           
        }
    }
}
