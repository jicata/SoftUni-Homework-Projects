using System;
using System.Collections.Generic;
using System.Linq;

namespace _07SortedSubsetSums
{
    class Program
    {
        static void Main()
        {

            int[][] penis = new int[3][];
            string[] asd = new string[0];
            int[] asdf = new int[3] { 1, null, 2 };
            for (int i = 0; i < penis.Length; i++)
            {
                string userInput = Console.ReadLine();
                asd = userInput.Split();
            }
            for (int i = 0; i < asd.Length; i++)
            {
                Console.Write("{0} ",asd[i]);
            }
            Console.WriteLine();
            

        }


        //int[,] firstma3x = new int[2,2]{ { 3, 4 }, { 5, 6 } };
        //int[,] secondma3x = new int[2,3]{{7,8,9},{4,5,6}};


        //int rows1 = firstma3x.GetLength(0);
        //int cols1 = firstma3x.GetLength(1);
        //int rows2 = secondma3x.GetLength(0);
        //int cols2 = secondma3x.GetLength(1);

        //if (cols1 != rows2)
        //{
        //    Console.WriteLine("ni staa brat");
        //}
        //int[,] resultMa3x = new int[rows1, cols2];
        //for (int i = 0; i < rows1; i++)
        //{
        //    for (int j = 0; j < cols2; j++)
        //    {
        //        resultMa3x[i, j] = 0;
        //        for (int k = 0; k < rows2; k++)
        //        {
        //            resultMa3x[i, j] += firstma3x[i, k] * secondma3x[k,j];
        //        }
        //    }
        //}
        //for (int i = 0; i < rows1; i++)
        //{
        //    for (int j = 0; j < cols2; j++)
        //    {
        //        Console.Write(" [{0}] ", resultMa3x[i,j]);
        //    }
        //    Console.WriteLine();
        //}
        
    }
}