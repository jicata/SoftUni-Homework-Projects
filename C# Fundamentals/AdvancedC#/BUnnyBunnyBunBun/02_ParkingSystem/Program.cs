namespace _02_ParkingSystem
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int[] boardCoordinates = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            int rows = boardCoordinates[0];
            int cols = boardCoordinates[1];

            char[,] board = new char[rows, cols];

            PrepMatrix(board);

            string parkingDirections = Console.ReadLine();

            while (parkingDirections != "stop")
            {
                string[] parkingDirectionsArgs = parkingDirections.Split();
                int entryRow = int.Parse(parkingDirectionsArgs[0]);
                int desiredRow = int.Parse(parkingDirectionsArgs[1]);
                int desiredCol = int.Parse(parkingDirectionsArgs[2]);
                int distance = 0;
                
                if (board[desiredRow, desiredCol] == '.')
                {
                    distance = CalculateDistance(entryRow, desiredRow, desiredCol, board);
                    board[desiredRow, desiredCol] = 'P';
                }
                else
                {
                    int[] freeSpotCoordinates = FindFreeSpot(desiredRow, desiredCol, board);
                    int freeRow = freeSpotCoordinates[0];
                    int freeCol = freeSpotCoordinates[1];
                    if (freeCol == 0)
                    {
                        Console.WriteLine("Row {0} full", freeRow);
                        parkingDirections = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        distance = CalculateDistance(entryRow, freeRow, freeCol, board);
                        board[freeRow, freeCol] = 'P';
                    }
                }
                Console.WriteLine(distance);
                parkingDirections = Console.ReadLine();
            }
            
          
        }

        private static int[] FindFreeSpot(int desiredRow, int desiredCol, char[,] board)
        {

            int freeColLeft = 0;
            int freeColRight = 0;
            int freeCol = 0;
            int[] freeSpotCoordinates = new int[2];
            

            bool foundLeft = false;
            bool foundRight = false;

            for (int i = desiredCol; i >= 1; i--)
            {
                if (board[desiredRow, i] == '.')
                {

                    freeColLeft = i;
                    foundLeft = true;
                    break;
                }
            }

            for (int i = desiredCol; i < board.GetLength(1); i++)
            {
                if (board[desiredRow, i] == '.')
                {

                    freeColRight = i;
                    foundRight = true;
                    break;
                }
            }
            if (foundRight && foundLeft)
            {
                int leftDistance = Math.Abs(desiredCol - freeColLeft);
                int rightDistance = Math.Abs(freeColRight - desiredCol);
                if (leftDistance == rightDistance)
                {
                    freeCol = freeColLeft;
                }
                else
                {
                    if (leftDistance < rightDistance)
                    {
                        freeCol = freeColLeft;
                    }
                    else
                    {
                        freeCol = freeColRight;
                    }
                }
               
            }
            else if (foundRight && !foundLeft)
            {
                freeCol = freeColRight;
            }
            else if (!foundRight && foundLeft)
            {
                freeCol = freeColLeft;
            }
            else if (!foundRight && !foundLeft)
            {
                freeCol = 0;
            }
            freeSpotCoordinates[0] = desiredRow;
            freeSpotCoordinates[1] = freeCol;
            return freeSpotCoordinates;
        }

        private static int CalculateDistance(int entryRow, int desiredRow, int desiredCol, char[,] board)
        {
            int rowSteps = Math.Abs(desiredRow - entryRow) + 1;
            int colSteps = 0 + desiredCol;
            return rowSteps + colSteps;
        }

        public static void PrepMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        matrix[i, j] = 'E';
                    }
                    else
                    {
                        matrix[i, j] = '.';
                    }

                }

            }
        }
        public static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
