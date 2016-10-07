namespace _05_PathsBetweenCellsInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Runtime.CompilerServices;

    class Program
    {
        static HashSet<string> visitedCells = new HashSet<string>();
        static void Main()
        {
            // hard-coded for ease of use, easily adjustable
            //char[,] matrix = new char[5, 4]
            //{
            //    {' ', ' ', ' ', ' '},
            //    {' ', '*', '*', ' '},
            //    {' ', '*', '*', ' '},
            //    {' ', '*', 'e', ' '},
            //    {' ', ' ', ' ', ' '},
            //};
            char[,] matrix = new char[5, 6]
            {
                {' ', ' ', ' ', ' ',' ', ' '},
                {' ', '*', '*', ' ','*', ' '},
                {' ', '*', '*', ' ','*', ' '},
                {' ', '*', 'e', ' ',' ', ' '},
                {' ', ' ', ' ', '*',' ', ' '},
            };
            List<char> movementDirections = new List<char>();
            int row = 0;
            int col = 0;
            char direction = 'S';
            RecursivePathFinding(row, col, matrix, movementDirections, direction);
        }

        private static void RecursivePathFinding(int row, int col, char[,] matrix, List<char> movementDirections, char direction)
        {
            if (!IsLegal(row, col, matrix))
            {
                return;
            }

            if (matrix[row, col] != ' ' && matrix[row,col] !='e')
            {
                return;
            }
            movementDirections.Add(direction);
            if (matrix[row, col] == 'e')
            {
                Console.WriteLine(string.Join(" ", movementDirections.Skip(1)));
                return;
            }

           

            matrix[row, col] = '.';

            RecursivePathFinding(row - 1, col, matrix, movementDirections, 'U');

            RecursivePathFinding(row, col + 1, matrix, movementDirections, 'R');

            RecursivePathFinding(row + 1, col, matrix, movementDirections, 'D');

            RecursivePathFinding(row, col - 1, matrix, movementDirections, 'L');

            movementDirections.RemoveAt(movementDirections.Count - 1);
            matrix[row, col] = ' ';


        }

        private static bool IsLegal(int row, int col, char[,] matrix)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}
