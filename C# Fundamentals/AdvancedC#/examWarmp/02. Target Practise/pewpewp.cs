using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Target_Practise
{
    class pewpewp
    {
        static void Main()
        {
            string[] matrixDimensions = Console.ReadLine().Split();
            int rows = int.Parse(matrixDimensions[0]);
            int cols = int.Parse(matrixDimensions[1]);
            char[,] stairCase = new char[rows, cols];
            int counter = 0;
            bool flag = true;

            string snake = Console.ReadLine();
            char[] snakeBits = snake.ToCharArray();
            List<char> snakeParts = new List<char>();
            
            for (int i = 0; i < rows*cols; i++)
            {
                if(counter >= snakeBits.Length)
                {
                    counter = 0;
                }
                snakeParts.Add(snakeBits[counter]);
                counter++;
            }

            counter = 0;
            for (int i = rows-1; i >= 0; i--)
            {
                if (i == rows - 1 || flag)
                {
                    for (int j = cols - 1; j >= 0; j--)
                    {
                        stairCase[i, j] = snakeParts[counter];
                        counter++;
                        flag = false;
                    }
                }
                else
                {
                    for (int k = 0; k < cols; k++)
                    {
                        stairCase[i, k] = snakeParts[counter];
                        counter++;
                        flag = true;
                    }
                }
                
            }
            string[] userCoordinates = Console.ReadLine().Split();
            int shotRow = int.Parse(userCoordinates[0]);
            int shotCol = int.Parse(userCoordinates[1]);
            int impact = int.Parse(userCoordinates[2]);



            if (impact == 0)
            {
                stairCase[shotRow, shotCol] = ' ';
            }
            else
            {
                for (int i = 0; i < stairCase.GetLength(0); i++)
                {
                    for (int j = 0; j < stairCase.GetLength(1); j++)
                    {
                        if (IsInsideRadius(i, j, shotRow, shotCol, impact))
                        {
                            stairCase[i, j] = ' ';
                        }
                    }
                }
            }



            for (int i = stairCase.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = 0; j < stairCase.GetLength(1); j++)
                {
                    if (stairCase[i, j] != ' ')
                    {
                        continue;
                    }
                    int currentRow = i - 1;
                    while (currentRow >= 0)
                    {
                        if (stairCase[currentRow,j] != ' ')
                        {
                            stairCase[i, j] = stairCase[currentRow, j];
                            stairCase[currentRow, j] = ' ';
                            break;
                        }
                        currentRow--;
                    }
                }
            }
            

            
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(stairCase[i, j]);
                }
                Console.WriteLine();
            }
            

            

        }
        private static bool IsInsideRadius(int checkRow, int checkCol, int impactRow, int impactCol, int shotRadius)
        {
            int deltaRow = checkRow - impactRow;
            int deltaCol = checkCol - impactCol;

            bool isInRadius = deltaRow * deltaRow + deltaCol * deltaCol <= shotRadius * shotRadius;

            return isInRadius;
        }
    }
}
 //private static void FireAShot(char[][] matrix, int impactRow, int impactCol, int shotRadius)
 //       {
 //           int matrixWidth = matrix[0].Length;

 //           for (int row = 0; row < matrix.Length; row++)
 //           {
 //               for (int col = 0; col < matrixWidth; col++)
 //               {
 //                   if (IsInsideRadius(row, col, impactRow, impactCol, shotRadius))
 //                   {
 //                       matrix[row][col] = ' ';
 //                   }
 //               }
 //           }
 //       }

 //       
