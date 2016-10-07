namespace TargetPractise
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int[] stairsDimensions = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            int rows = stairsDimensions[0];
            int cols = stairsDimensions[1];

            char[,] stairs = new char[rows,cols];
            string snake = Console.ReadLine();

            FillStairs(stairs, snake);

            DemolishTheEvilReptile(stairs);

            DesintegrateTheScalyMonster(stairs);

            PrintMatrix(stairs);

        }

        private static void DesintegrateTheScalyMonster(char[,] stairs)
        {
            for (int row = stairs.GetLength(0) - 1; row >= 0; row--)
            {
                for (int col = 0; col < stairs.GetLength(1); col++)
                {
                    for (int innerRow = stairs.GetLength(0) - 1; innerRow >= 0; innerRow--)
                    {
                        if (stairs[innerRow, col] == ' ')
                        {
                            if (innerRow - 1 >= 0)
                            {
                                stairs[innerRow, col] = stairs[innerRow - 1, col];
                                stairs[innerRow - 1, col] = ' ';
                            }
                        }
                    }
                }
            }
        }

        private static void DemolishTheEvilReptile(char[,] stairs)
        {
            int[] shotCoordinates = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

            int impactRow = shotCoordinates[0];
            int impactCol = shotCoordinates[1];
            int impactRadius = shotCoordinates[2];

            for (int i = 0; i < stairs.GetLength(0); i++)
            {
                for (int j = 0; j < stairs.GetLength(1); j++)
                {
                    if (IsInsideRadius(i, j, impactRow, impactCol, impactRadius))
                    {
                        stairs[i, j] = ' ';
                    }
                }
            }
        }

        private static void FillStairs(char[,] stairs, string snake)
        {
            int count = 0;
            bool goLeft = true;
            for (int row = stairs.GetLength(0) - 1; row >= 0; row--)
            {
                if (goLeft)
                {
                    for (int col = stairs.GetLength(1) - 1; col >= 0; col--)
                    {
                        if (count == snake.Length)
                        {
                            count = 0;
                        }
                        stairs[row, col] = snake[count];
                        count++;
                    }
                    goLeft = false;
                }
                else
                {
                    for (int col = 0; col < stairs.GetLength(1); col++)
                    {
                        if (count == snake.Length)
                        {
                            count = 0;
                        }
                        stairs[row, col] = snake[count];
                        count++;
                    }
                    goLeft = true;
                }
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

        private static bool IsInsideRadius(int checkRow, int checkCol, int impactRow, int impactCol, int shotRadius)
        {
            int deltaRow = checkRow - impactRow;
            int deltaCol = checkCol - impactCol;

            bool isInRadius = deltaRow * deltaRow + deltaCol * deltaCol <= shotRadius * shotRadius;

            return isInRadius;
        }
    }
}
