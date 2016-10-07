namespace _02_AreasInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static bool[,] visited;
        static void Main()
        {

            string firstLine = Console.ReadLine();
            int rows = int.Parse(firstLine.Substring(15));
            string thisRow = Console.ReadLine();
            int cols = thisRow.Length;
            char[,] matrix = new char[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                char[] charRow = thisRow.ToCharArray();
                for (int j = 0; j < charRow.Length; j++)
                {
                    matrix[i, j] = charRow[j];
                }
                thisRow = Console.ReadLine();
            }
            visited = new bool[rows, cols];
            Dictionary<char,int> areas = new Dictionary<char, int>();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    char currentChar = matrix[row, col];
                    if (!visited[row, col])
                    {
                        ConnectedAreasDFS(matrix, row, col, currentChar);
                        if (!areas.ContainsKey(currentChar))
                        {
                            areas.Add(currentChar, 1);
                        }
                        else
                        {
                            areas[currentChar]++;
                        }
                    }
                }
            }

            Console.WriteLine("Areas: {0}",areas.Values.Sum());
            var sorted = areas.OrderBy(x => x.Key);
            foreach (var area in sorted)
            {
                Console.WriteLine("Letter '{0}' -> {1}", area.Key, area.Value);
            }
        }

        private static void ConnectedAreasDFS(char[,] matrix, int row, int col, char currentChar)
        {
            visited[row, col] = true;
            if (IsLegal(matrix,row+1,col) && !visited[row+1, col] && currentChar == matrix[row+1,col])
            {
               ConnectedAreasDFS(matrix, row+1, col, currentChar);
            }
            if (IsLegal(matrix,row-1,col) && !visited[row - 1, col] && currentChar == matrix[row - 1, col])
            {
                ConnectedAreasDFS(matrix, row - 1, col, currentChar);
            }
            if (IsLegal(matrix,row,col+1) && !visited[row, col+1] && currentChar == matrix[row, col+1])
            {
                ConnectedAreasDFS(matrix, row, col+1, currentChar);
            }
            if (IsLegal(matrix,row,col-1) && !visited[row, col-1] && currentChar == matrix[row, col-1])
            {
                ConnectedAreasDFS(matrix, row, col-1, currentChar);
            }
        }

        private static bool IsLegal(char[,] matrix, int row, int col)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
