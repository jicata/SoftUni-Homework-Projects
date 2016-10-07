using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shuffleTheMa3x
{
    class shuffle
    {
        static void Main()
        {

            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());
            string userInput = string.Empty;
            string[,] matrix = new string[row, col];
           
            // Fill up the ma3x!
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = Console.ReadLine();
                }

            }
           
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write("{0}, ",matrix[i,j]);
                }
                Console.WriteLine();
            }
            userInput = Console.ReadLine();

            while (userInput != "END")
            {
                string[] readInput = userInput.Split();
                if (readInput[0] == "swap" && readInput.Length == 5)
                {
                    int x1 = int.Parse(readInput[1]);
                    int x2 = int.Parse(readInput[2]);
                    int y1 = int.Parse(readInput[3]);
                    int y2 = int.Parse(readInput[4]);
                    if ((x1 < row && x2 < col) && (y1 < row && y2< col))
                    {
                        string temp = matrix[x1, x2];
                        matrix[x1, x2] = matrix[y1, y2];
                        matrix[y1, y2] = temp;
                        for (int i = 0; i < row; i++)
                        {
                            for (int j = 0; j < col; j++)
                            {
                                Console.Write("{0} ",matrix[i, j]);
                            }
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                    }
                    
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
                userInput = Console.ReadLine();
                
            }
            

        }
    }
}
