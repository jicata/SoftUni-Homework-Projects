using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultidimensionalArrays
{
    class mdAr
    {
        static void Main()
        {
            int row = 2;
            int col = 2;
             
            int[,] keanu = new int[row,col];
            int[,] reeves = new int[row,col];
            int[,] neo = new int[row,col];

            Random rng = new Random();
            int randomNum = rng.Next(0, 9);

            int[] penis = new int[10];

            for (int i = 0; i < penis.Length; i++)
            {
                penis[i] = rng.Next(1, 10);
            }

            for (int i = 0; i < row ; i++)
			{
			    for (int j = 0; j < col; j++)
			    {
                    
			        keanu[i,j] = penis[rng.Next(1, 10)];
                    reeves[i, j] = penis[rng.Next(1, 10)];

			    }
			}
            //-----------------------------------------
            for (int i = 0; i < keanu.GetLength(0); i++)
            {
                for (int j = 0; j < keanu.GetLength(1); j++)
                {
                    Console.Write(" " + keanu[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            for (int i = 0; i < reeves.GetLength(0); i++)
            {
                for (int j = 0; j < reeves.GetLength(1); j++)
                {
                    Console.Write(" " + reeves[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

           
            //-----------------------------------------
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    
                    for (int k = 0; k < col; k++)
                    {
                        neo[i, j] += keanu[i, k] * reeves[k, j];
                        int chep= neo[i, j];
                        //Console.WriteLine(chep);
                    }
                }
            }
            // 1 2  5 6
            // 3 4  7 8
            //
            // 
            //

            //




            //int width1 = firstMatrix.GetLength(1);
            //int height1 = firstMatrix.GetLength(0);
            //int width2 = secondMatrix.GetLength(1);
            //int height2 = secondMatrix.GetLength(0);

            //if (width1 != height2)
            //{
            //    throw new ArgumentException("Invalid dimensions!");
            //}

            //int[,] resultMatrix = new int[height1, width2];
            //for (int row = 0; row < height1; row++)
            //{
            //    for (int col = 0; col < width2; col++)
            //    {
            //        resultMatrix[row, col] = 0;
            //        for (int i = 0; i < width1; i++)
            //        {
            //            resultMatrix[row, col] += firstMatrix[row, i] * secondMatrix[i, col];
            //        }
            //    }
            //}

            //0,0 X 0,0
            //+
            //0,1 X 1,1







           

           

            for (int i = 0; i < neo.GetLength(0); i++)
            {
                for (int j = 0; j < neo.GetLength(1); j++)
                {
                    Console.Write(" " + neo[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
