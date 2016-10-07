namespace BunkerBuster
{
    using System;
    using System.Linq;
    using System.Security.Permissions;

    class Program
    {
        static void Main()
        {
            string[] dimensions = Console.ReadLine().Split();
            int rows = int.Parse(dimensions[0]);
            int cols = int.Parse(dimensions[1]);
            int[,] matrix = new int[rows,cols];
            int count = 0;

            for (int i = 0; i < rows; i++)
            {
                int[] matrixLayout = Console.ReadLine().Trim().Split().Select(x => int.Parse(x)).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = matrixLayout[j];
                }
                
            }
            string command = Console.ReadLine();
            while(command != "cease fire!")
            {
                string[] commandArgs = command.Trim().Split();
                int targetRow = int.Parse(commandArgs[0]);
                int targetCol = int.Parse(commandArgs[1]);
                int initialBombPower = char.Parse(commandArgs[2]);
                BombsAway(targetRow, targetCol, initialBombPower, matrix);

                command = Console.ReadLine();
            }
            double destroyedBunkers = 0;
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] <= 0)
                    {
                        destroyedBunkers++;
                    }
                }
            }
            double totalBunkers = rows * cols;
            double percentageDestroyed = (destroyedBunkers/totalBunkers)*100;
            Console.WriteLine("Destroyed bunkers: " + destroyedBunkers);
            Console.WriteLine(string.Format("Damage done: {0:F1} %", percentageDestroyed));
        }

        public static void BombsAway(int bombRow, int bombCol, int initialBombPower, int[,] matrix)
        {
            int bombPower = (int)Math.Ceiling(initialBombPower / 2.0);

            matrix[bombRow, bombCol] -= initialBombPower;

            //up
            if (IsLegalCell(bombRow - 1, bombCol - 1, matrix))
            {
                matrix[bombRow - 1, bombCol - 1] -= bombPower;
            }
            if (IsLegalCell(bombRow - 1, bombCol, matrix))
            {
                matrix[bombRow - 1, bombCol] -= bombPower;
            }
            if (IsLegalCell(bombRow - 1, bombCol + 1, matrix))
            {
                matrix[bombRow - 1, bombCol + 1] -= bombPower;
            }

            // left and right
            if (IsLegalCell(bombRow, bombCol - 1, matrix))
            {
                matrix[bombRow, bombCol - 1] -= bombPower;
            }
            if (IsLegalCell(bombRow, bombCol + 1, matrix))
            {
                matrix[bombRow, bombCol + 1] -= bombPower;
            }

            // down
            if (IsLegalCell(bombRow + 1, bombCol - 1, matrix))
            {
                matrix[bombRow + 1, bombCol - 1] -= bombPower;
            }
            if (IsLegalCell(bombRow + 1, bombCol, matrix))
            {
                matrix[bombRow + 1, bombCol] -= bombPower;
            }
            if (IsLegalCell(bombRow + 1, bombCol + 1, matrix))
            {
                matrix[bombRow + 1, bombCol + 1] -= bombPower;
            }

        }

        public static bool IsLegalCell(int row, int col, int[,] matrix)
        {
            bool legal = false;
            if(row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
            {
                legal = true;
            }
            return legal;
        }
        public static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
