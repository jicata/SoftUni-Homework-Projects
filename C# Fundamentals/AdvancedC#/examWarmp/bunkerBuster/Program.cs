using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bunkerBuster
{
    class Program
    {
        static void Main()
        {
            int[] dimensions = Console.ReadLine().Trim().Split().Select(x => int.Parse(x)).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            int[,] field = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                int[] values = Console.ReadLine().Trim().Split(' ').Select(x => int.Parse(x)).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    field[i, j] = values[j];
                }
            }
            string input = Console.ReadLine();
            while (input != "cease fire!")
            {
                var command = input.Trim().Split();
                int row =int.Parse(command[0]);
                int col = int.Parse(command[1]);
                int dmg = char.Parse(command[2]);
                int halfDmg = (int)Math.Ceiling(dmg / 2.0);

                TheDmg(field, dmg, row, col);

                input = Console.ReadLine();
            }
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write(field[i, j]);
                }
                Console.WriteLine();
            }
            int destroyedCells = DeadCells(field);
            int totalCells = rows * cols;
            double percentage = (destroyedCells / (double)totalCells) * 100;

            Console.WriteLine("Bunkers Bunkered : {0}",destroyedCells);
            Console.WriteLine("Total dmg: {0:f1}%", percentage);
        }
        private static int DeadCells(int[,] field)
        {
            int counter = 0;
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i,j] <= 0 )
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }
        private static void TheDmg (int[,] matrix, int dmg, int row, int col)
        {
            int halfDmg = (int)Math.Ceiling(dmg / 2.0);

            int startRow = Math.Max(0,row - 1);
            int endRow = Math.Min(matrix.GetLength(0)-1, row + 1);
            int startCol = Math.Max(0, col - 1);
            int endCol = Math.Min(matrix.GetLength(1) - 1, col + 1);

            for (int i = startRow; i <= endRow; i++)
            {
                for (int j = startCol; j <= endCol; j++)
                {
                    if (i == row && j == col)
                    {
                        matrix[i, j] -= dmg;
                    }
                    else
                    {
                        matrix[i, j] -= halfDmg;
                    }
                }

            }

        }
    }

}
