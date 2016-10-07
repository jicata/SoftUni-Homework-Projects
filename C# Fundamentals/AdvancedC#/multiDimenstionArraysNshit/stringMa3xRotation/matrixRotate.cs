using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stringMa3xRotation
{
    class matrixRotate
    {
        static void Main()
        {
            string[] rawUserInput = Console.ReadLine().Split(new char[] {'(', ')'}, StringSplitOptions.RemoveEmptyEntries);
            int degrees = int.Parse(rawUserInput[1]) % 360;
           

            string userInputString = Console.ReadLine();
            List<string> inputStorage = new List<string>();
            StringBuilder userFixed = new StringBuilder();
            string currentEl = string.Empty;
            

            int longestString = int.MinValue;

            while (userInputString != "END")
            {
                
                inputStorage.Add(userInputString);
                if (userInputString.Length > longestString)
                {
                    longestString = userInputString.Length;
                }
                userInputString = Console.ReadLine();

            }
            char[,] matrix = new char[inputStorage.Count, longestString];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                currentEl = inputStorage[i].PadRight(longestString,' ');
                for (int j = 0; j < longestString ; j++)
                {
                    matrix[i, j] = currentEl[j];
                }
            }

           
            if (degrees == 0)
            {
                PrintMatrix(matrix);
            }
            if (degrees == 90)
            {
                char[,] rotatoPotato = new char[matrix.GetLength(1), matrix.GetLength(0)];
                for (int i = 0; i < rotatoPotato.GetLength(0); i++)
                {
                    for (int j = 0; j < rotatoPotato.GetLength(1); j++)
                    {
                        rotatoPotato[i, j] = matrix[matrix.GetLength(0) - j - 1, i];
                    }
                }
                PrintMatrix(rotatoPotato);
                
            }
            else if(degrees == 180)
            {
                char[,] rotatoPotato = new char[matrix.GetLength(0), matrix.GetLength(1)];
                for (int i = 0; i < rotatoPotato.GetLength(0); i++)
                {
                    for (int j = 0; j < rotatoPotato.GetLength(1); j++)
                    {
                        rotatoPotato[i, j] = matrix[matrix.GetLength(0) - i -1 , matrix.GetLength(1) - j - 1];
                    }
                }
                PrintMatrix(rotatoPotato);
                
            }
            else if (degrees == 270)
            {
                char[,] rotatoPotato = new char[matrix.GetLength(1), matrix.GetLength(0)];
                for (int i = 0; i < rotatoPotato.GetLength(0); i++)
                {
                    for (int j = 0; j < rotatoPotato.GetLength(1); j++)
                    {
                        rotatoPotato[i, j] = matrix[j, matrix.GetLength(1) - i - 1];
                    }
                }
                PrintMatrix(rotatoPotato);
                
            }


        }
        public static void PrintMatrix(char[,] loMatrico)
        {
            for (int i = 0; i < loMatrico.GetLength(0); i++)
            {

                for (int j = 0; j < loMatrico.GetLength(1); j++)
                {

                    Console.Write(loMatrico[i, j]);
                }
                Console.WriteLine();

            }
        }
    }
}
