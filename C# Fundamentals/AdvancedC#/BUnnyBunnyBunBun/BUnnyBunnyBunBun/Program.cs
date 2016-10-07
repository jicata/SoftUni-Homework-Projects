namespace BUnnyBunnyBunBun
{
    using System;

    class Program
    {
        public static void Main()
        {
            string[] matrixDimensions = Console.ReadLine().Split();
            int rows = int.Parse(matrixDimensions[0]);
            int cols = int.Parse(matrixDimensions[1]);

            char[,] gameBoard = new char[rows,cols];

            FIllMatrix(rows, gameBoard);
            bool hasWon = false;
            bool hasDied = false;

            string playerDirections = Console.ReadLine();

            for (int i = 0; i < playerDirections.Length; i++)
            {
                int[] playerPosition = FindPlayer(gameBoard);
                int[] newPlayerPosition = ExecuteMovementCommand(playerDirections[i], playerPosition[0], playerPosition[1]);

                int newPlayerRow = newPlayerPosition[0];
                int newPlayerCol = newPlayerPosition[1];
                if ((newPlayerRow < 0 || newPlayerRow >= rows) || (newPlayerCol < 0 || newPlayerCol >= cols))
                {
                    gameBoard[playerPosition[0], playerPosition[1]] = '.';
                    hasWon = true;
                }
                else if (gameBoard[newPlayerRow, newPlayerCol] == 'B')
                {
                    hasDied = true;
                }
                else
                {
                    gameBoard[playerPosition[0], playerPosition[1]] = '.';
                    gameBoard[newPlayerRow, newPlayerCol] = 'P';
                }

                SpawnBunnies(rows, cols, gameBoard);

                if (!hasWon && gameBoard[newPlayerRow, newPlayerCol] == 'B')
                {
                    hasDied = true;
                }

                if (hasWon)
                {
                    PrintMatrix(gameBoard);
                    Console.WriteLine("won: {0} {1}", playerPosition[0],playerPosition[1]);
                    break;
                }
                if (hasDied)
                {
                    PrintMatrix(gameBoard);
                    Console.WriteLine("dead: {0} {1}",newPlayerRow, newPlayerCol);
                    break;
                }
            }
        }

        private static int[] ExecuteMovementCommand(char playerDirection, int playerRow, int playerCol)
        {
            int[] newPlayerPosition = new int[2];
            switch (playerDirection)
            {
                case 'U':
                    playerRow --;
                    break;
                case 'D':
                    playerRow ++;
                    break;
                case 'L':
                    playerCol --;
                    break;
                case 'R':
                    playerCol ++;
                    break;
            }
            newPlayerPosition[0] = playerRow;
            newPlayerPosition[1] = playerCol;

            return newPlayerPosition;

        }

        private static int[] FindPlayer(char[,] gameBoard)
        {
            int[] playerPosition = new int[2];
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    if (gameBoard[i, j] == 'P')
                    {
                        playerPosition[0] = i;
                        playerPosition[1] = j;
                    }
                }
                
            }
            return playerPosition;
        }

        private static void SpawnBunnies(int rows, int cols, char[,] gameBoard)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (gameBoard[i, j] == 'B')
                    {
                        BunnyMatingSeason(gameBoard, i, j);
                    }
                }
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (gameBoard[i, j] == 'N')
                    {
                        gameBoard[i, j] = 'B';
                    }
                }
            }
        }

        private static void FIllMatrix(int rows, char[,] gameBoard)
        {
            for (int i = 0; i < rows; i++)
            {
                char[] initialBoardRow = Console.ReadLine().ToCharArray();
                for (int j = 0; j < initialBoardRow.Length; j++)
                {
                    gameBoard[i, j] = initialBoardRow[j];
                }
            }
        }

        private static void BunnyMatingSeason(char[,] gameBoard, int row, int col)
        {
            if (row - 1 >= 0 && (gameBoard[row - 1, col] == '.' || gameBoard[row - 1, col] == 'P'))
            {
                gameBoard[row - 1, col] = 'N';
            }
            if (row + 1 < gameBoard.GetLength(0) && (gameBoard[row + 1, col] == '.' || gameBoard[row + 1, col] == 'P'))
            {
                gameBoard[row + 1, col] = 'N';
            }
            if (col - 1 >= 0 && (gameBoard[row, col - 1] == '.' | gameBoard[row, col - 1] == 'P'))
            {
                gameBoard[row, col - 1] = 'N';
            }
            if (col + 1 < gameBoard.GetLength(1) && (gameBoard[row, col + 1] == '.' || gameBoard[row, col + 1] == 'P'))
            {
                gameBoard[row, col + 1] = 'N';
            }
        }

        public static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
