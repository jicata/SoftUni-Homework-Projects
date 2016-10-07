namespace _08_DistanceInLabyrinthBFS
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            // works in every scenario
            string[,] board = new string[3, 3];

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
            var startingCell = new Cell(startingRow, startingCol, 0);
            Queue<Cell> cells = new Queue<Cell>();
            cells.Enqueue(startingCell);
            while (cells.Count > 0)
            {
                var currentCell = cells.Dequeue();
                if (IsLegalCell(currentCell.Row - 1, currentCell.Col, board))
                {
                    cells.Enqueue(new Cell(currentCell.Row-1, currentCell.Col, currentCell.Steps+1));
                    board[currentCell.Row - 1, currentCell.Col] = (currentCell.Steps + 1).ToString();
                }
                if (IsLegalCell(currentCell.Row , currentCell.Col+1, board))
                {
                    cells.Enqueue(new Cell(currentCell.Row, currentCell.Col+1, currentCell.Steps + 1));
                    board[currentCell.Row, currentCell.Col+1] = (currentCell.Steps + 1).ToString();
                }
                if (IsLegalCell(currentCell.Row + 1, currentCell.Col, board))
                {
                    cells.Enqueue(new Cell(currentCell.Row + 1, currentCell.Col, currentCell.Steps + 1));
                    board[currentCell.Row + 1, currentCell.Col] = (currentCell.Steps + 1).ToString();
                }
                if (IsLegalCell(currentCell.Row, currentCell.Col - 1, board))
                {
                    cells.Enqueue(new Cell(currentCell.Row, currentCell.Col - 1, currentCell.Steps + 1));
                    board[currentCell.Row, currentCell.Col - 1] = (currentCell.Steps + 1).ToString();
                }
            }
            Console.WriteLine();
            PrintMatrix(board);
            
        }

        public static bool IsLegalCell(int row, int col, string[,] board)
        {
            bool legal = false;
            if (row >= 0 && row < board.GetLength(0) && col >= 0 && col < board.GetLength(1))
            {
                if (board[row, col] == "0")
                {
                    legal = true;
                }
            }
            return legal;
        }

        public static void PrintMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == "0")
                    {
                        matrix[i, j] = "u";
                    }
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }

    public class Cell
    {
        public Cell(int row, int col, int steps)
        {
            this.Row = row;
            this.Col = col;
            this.Steps = steps;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public int Steps { get; set; }
    }
}
