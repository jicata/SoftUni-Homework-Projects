using System;
using System.Collections.Generic;

class PlusRemove
{
    static void Main()
    {
        //shameless copy paste
        List<List<char>> board = new List<List<char>>();

        string lineContents = Console.ReadLine();
        for (int row = 0; lineContents != "END"; row++)
        {
            board.Add(new List<char>(lineContents.Length));
            for (int col = 0; col < lineContents.Length; col++)
            {
                board[row].Add(lineContents[col]);
            }
            lineContents = Console.ReadLine();
        }

        char currentValue = '\0';
        HashSet<KeyValuePair<int, int>> coordinatesSet = new HashSet<KeyValuePair<int, int>>();
        for (int row = 1; row < board.Count - 1; row++)
        {
            for (int col = 1; col < board[row].Count - 1; col++)
            {
                currentValue = Char.ToLower(board[row][col]);
                if (col < board[row - 1].Count && currentValue.Equals(Char.ToLower(board[row - 1][col]))
                    && currentValue.Equals(Char.ToLower(board[row][col - 1])) && currentValue.Equals(Char.ToLower(board[row][col + 1]))
                    && col < board[row + 1].Count && currentValue.Equals(Char.ToLower(board[row + 1][col])))
                {
                    coordinatesSet.Add(new KeyValuePair<int, int>(row, col));
                    coordinatesSet.Add(new KeyValuePair<int, int>(row - 1, col));
                    coordinatesSet.Add(new KeyValuePair<int, int>(row + 1, col));
                    coordinatesSet.Add(new KeyValuePair<int, int>(row, col + 1));
                    coordinatesSet.Add(new KeyValuePair<int, int>(row, col - 1));
                }
            }
        }

        for (int row = 0; row < board.Count; row++)
        {
            for (int col = 0; col < board[row].Count; col++)
            {
                KeyValuePair<int, int> curKeyValuePair = new KeyValuePair<int, int>(row, col);
                if (!coordinatesSet.Contains(curKeyValuePair))
                {
                    Console.Write(board[row][col]);
                }
            }
            Console.WriteLine();
        }
    }
}