namespace _8Queens
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    class Program
    {
        static HashSet<int> attackedRows = new HashSet<int>();
        static HashSet<int> attackedColums = new HashSet<int>();
        static HashSet<int> attackedLeftDiag = new HashSet<int>();
        static HashSet<int> attackedRightDiag = new HashSet<int>();
        const int Size = 8;
        static bool[,] chessboard = new bool[Size,Size];
        private static int soloutionsFound = 0;
            
        static void Main()
        {
            PutQueens(0);
            Console.WriteLine(soloutionsFound);
        }

        static void PutQueens(int row)
        {
            if (row == Size)
            {
                PrintSolution(chessboard);
                Console.WriteLine();
                return;
            }
            else
            {
                for (int col = 0; col < Size; col++)
                {
                    if (CanPlaceQueen(row, col))
                    {
                        MarkAllAttackedPositions(row, col);
                        PutQueens(row+1);
                        UnmarkAllAttackedPositions(row, col);
                    }
                }
            }
        }

        private static void PrintSolution(bool[,] chessBoard)
        {
            for (int i = 0; i < chessBoard.GetLength(0); i++)
            {
                for (int j = 0; j < chessBoard.GetLength(1); j++)
                {
                    if (chessBoard[i, j] == true)
                    {
                        Console.Write("Q");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            soloutionsFound++;
        }

        private static void MarkAllAttackedPositions(int row, int col)
        {
            attackedRows.Add(row);
            attackedColums.Add(col);
            attackedLeftDiag.Add(row - col);
            attackedRightDiag.Add(row + col);
            chessboard[row, col] = true;
        }

        private static void UnmarkAllAttackedPositions(int row, int col)
        {
            attackedRows.Remove(row);
            attackedColums.Remove(col);
            attackedLeftDiag.Remove(row - col);
            attackedRightDiag.Remove(row + col);
            chessboard[row, col] = false;
        }

        static bool CanPlaceQueen(int row, int col)
        {
            var positionOccupied =
                attackedRows.Contains(row) ||
                attackedColums.Contains(col) ||
                attackedLeftDiag.Contains(row - col) ||
                attackedRightDiag.Contains(row + col);
            return !positionOccupied;
        }
    }
}
