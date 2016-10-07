namespace _08_DistanceInLabyrith
{
    using System;

    class Program
    {
        static void Main()
        {
            // solves the problem but fails in certain scenarios
            string[,] board = new string[6,6];

            for (int i = 0; i < board.GetLength(0); i++)
            {
                string labyrinthLayout = Console.ReadLine();
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = labyrinthLayout[j].ToString();
                }
            }
            int startingRow = 0;
            int startingCol = 0;


            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == "*")
                    {
                        startingRow = i;
                        startingCol = j;
                        break;
                    }
                }
            }
            StarPlatform(board, startingRow, startingCol);
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == "0")
                    {
                        board[i, j] = "u";
                    }
                }
            }
            PrintMatrix(board);

        }

        public static void PrintMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]+"|");
                }
                Console.WriteLine();
            }
        }

        public static void StarPlatform(string[,] matrix, int row, int col)
        {
           
            //check up
            bool upPossible = CheckAndMarkUp(matrix, row, col);
            //check right
            bool rightPossible = CheckAndMarkRight(matrix, row, col);
            //check down
            bool downPossible = CheckAndMarkDown(matrix, row, col);
            //check left
            bool leftPossible = CheckAndMarkLeft(matrix, row, col);

            if (upPossible)
            {
                StarPlatform(matrix, row-1, col);
            }
            if (rightPossible)
            {
                StarPlatform(matrix, row, col+1);
            }
            if (downPossible)
            {
                StarPlatform(matrix, row+1, col);
            }
            if (leftPossible)
            {
                StarPlatform(matrix, row, col-1);
            }
            
        }

        private static bool CheckAndMarkLeft(string[,] matrix, int row, int col)
        {
            bool leftPossible = false;
            if (col - 1 >= 0)
            {
                int result = 0;
                bool visited = int.TryParse(matrix[row, col - 1], out result);
                if ((matrix[row, col - 1] != "x" && matrix[row, col - 1] != "*") && result == 0)
                {
                    if (matrix[row, col] == "*")
                    {
                        matrix[row, col - 1] = 1.ToString();
                    }
                    else
                    {
                        matrix[row, col - 1] = (int.Parse(matrix[row, col]) + 1).ToString();
                    }
                    leftPossible = true;
                }
            }
            return leftPossible;
        }

        private static bool CheckAndMarkDown(string[,] matrix, int row, int col)
        {
            bool downPossible = false;
            if (row + 1 < matrix.GetLength(0))
            {
                int result = 0;
                bool visited = int.TryParse(matrix[row + 1, col], out result);
                if ((matrix[row + 1, col] != "x" && matrix[row + 1, col] != "*") && result == 0)
                {
                    if (matrix[row, col] == "*")
                    {
                        matrix[row + 1, col] = 1.ToString();
                    }
                    else
                    {
                        matrix[row + 1, col] = (int.Parse(matrix[row, col]) + 1).ToString();
                    }
                    downPossible = true;
                }
            }
            return downPossible;
        }

        private static bool CheckAndMarkRight(string[,] matrix, int row, int col)
        {
            bool rightPossible = false;
            if (col + 1 < matrix.GetLength(1))
            {
                int result = 0;
                bool visited = int.TryParse(matrix[row, col + 1], out result);
                if ((matrix[row, col + 1] != "x" && matrix[row, col + 1] != "*") && result == 0)
                {
                    if (matrix[row, col] == "*")
                    {
                        matrix[row, col + 1] = 1.ToString();
                    }
                    else
                    {
                        matrix[row, col + 1] = (int.Parse(matrix[row, col]) + 1).ToString();
                    }
                    rightPossible = true;
                }
            }
            return rightPossible;
        }

        private static bool CheckAndMarkUp(string[,] matrix, int row, int col)
        {
            bool upPossible = false;
            if (row - 1 >= 0)
            {
                int result = 0;
                bool visited = int.TryParse(matrix[row - 1, col], out result);
                if ((matrix[row - 1, col] != "x" && matrix[row - 1, col] != "*") && result == 0)
                {
                    //check if we're at the starting cell
                    if (matrix[row, col] == "*")
                    {
                        matrix[row - 1, col] = 1.ToString();
                    }
                    else
                    {
                        matrix[row - 1, col] = (int.Parse(matrix[row, col]) + 1).ToString();
                    }

                    upPossible = true;
                }
            }
            return upPossible;
        }
    }
}
