namespace _03_RideTheHorse
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            int[,] chessBoard = new int[rows, cols];



            int horseRow = int.Parse(Console.ReadLine());
            int horseCol = int.Parse(Console.ReadLine());
            chessBoard[horseRow, horseCol] = 1;

            Queue<Cell> cells = new Queue<Cell>();
            cells.Enqueue(new Cell(horseRow, horseCol));

            while (cells.Count > 0)
            {
                var currentCell = cells.Dequeue();
                int currentStep = chessBoard[currentCell.Row, currentCell.Col];
                //up left
                if (IsLegalCell(currentCell.Row - 2, currentCell.Col - 1, chessBoard))
                {
                    cells.Enqueue(new Cell(currentCell.Row - 2, currentCell.Col - 1));
                    chessBoard[currentCell.Row - 2, currentCell.Col - 1] = currentStep + 1;
                }
                //up right
                if (IsLegalCell(currentCell.Row - 2, currentCell.Col + 1, chessBoard))
                {
                    cells.Enqueue(new Cell(currentCell.Row - 2, currentCell.Col + 1));
                    chessBoard[currentCell.Row - 2, currentCell.Col + 1] = currentStep + 1;
                }
                //right up
                if (IsLegalCell(currentCell.Row - 1, currentCell.Col + 2, chessBoard))
                {
                    cells.Enqueue(new Cell(currentCell.Row - 1, currentCell.Col + 2));
                    chessBoard[currentCell.Row - 1, currentCell.Col + 2] = currentStep + 1;
                }
                //right down
                if (IsLegalCell(currentCell.Row + 1, currentCell.Col + 2, chessBoard))
                {
                    cells.Enqueue(new Cell(currentCell.Row + 1, currentCell.Col + 2));
                    chessBoard[currentCell.Row + 1, currentCell.Col + 2] = currentStep + 1;
                }
                //down right
                if (IsLegalCell(currentCell.Row + 2, currentCell.Col + 1, chessBoard))
                {
                    cells.Enqueue(new Cell(currentCell.Row + 2, currentCell.Col + 1));
                    chessBoard[currentCell.Row + 2, currentCell.Col + 1] = currentStep + 1;
                }
                //down left
                if (IsLegalCell(currentCell.Row + 2, currentCell.Col - 1, chessBoard))
                {
                    cells.Enqueue(new Cell(currentCell.Row + 2, currentCell.Col - 1));
                    chessBoard[currentCell.Row + 2, currentCell.Col - 1] = currentStep + 1;
                }
                //left down
                if (IsLegalCell(currentCell.Row + 1, currentCell.Col - 2, chessBoard))
                {
                    cells.Enqueue(new Cell(currentCell.Row + 1, currentCell.Col - 2));
                    chessBoard[currentCell.Row + 1, currentCell.Col - 2] = currentStep + 1;
                }
                //left up
                if (IsLegalCell(currentCell.Row - 1, currentCell.Col - 2, chessBoard))
                {
                    cells.Enqueue(new Cell(currentCell.Row - 1, currentCell.Col - 2));
                    chessBoard[currentCell.Row - 1, currentCell.Col - 2] = currentStep + 1;
                }
              
            }
            Console.WriteLine();
            PrintMiddleCol(chessBoard);
          
        }

        private static bool IsLegalCell(int row, int col, int[,] chessBoard)
        {
            bool legal = false;
            if (row >= 0 && row < chessBoard.GetLength(0) && col >= 0 && col < chessBoard.GetLength(1))
            {
                if (chessBoard[row, col] == 0)
                {
                    legal = true;
                }
            }
            return legal;
        }

        public static void PrintMatrix(int[,] matrix)
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

        public static void PrintMiddleCol(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == matrix.GetLength(1)/2)
                    {
                        Console.Write(matrix[i, j] + " ");
                    }
                   
                }
                Console.WriteLine();
            }
        }
    }
}
