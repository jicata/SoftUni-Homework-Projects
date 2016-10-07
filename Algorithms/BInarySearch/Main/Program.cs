using System;


namespace Main
{
    class Program
    {
        static void Main()
        {
            char[,] Board = new char[3,3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Board[i, j] = '0';
                    Console.Write("\"" + Board[i,j] + "\" ");
                }
                Console.WriteLine();
            }
            
        }
        public char CheckHorizontal(char[,] board)
        {
            for (int i = 0; i < 3; i++)
            {
                char firstCell = board[i, 0];
                char secondCell = board[i, 1];
                char thirdCell = board[i, 2];

                if (firstCell == secondCell && firstCell == thirdCell)
                {
                    return firstCell;
                }
            }
            return 'K';
        }

        public char CheckVertical(char[,] board)
        {
            for (int i = 0; i < 3; i++)
            {
                char firstCell = board[0, i];
                char secondCell = board[1, i];
                char thirdCell = board[2, i];

                if (firstCell == secondCell && firstCell == thirdCell)
                {
                    return firstCell;
                }
            }
            return 'K';
        }

        public char CheckDiagonal(char[,] board)
        {

            char firstCell = ' ';
            char secondCell = ' ';
            char thirdCell = ' ';

            for (int i = 0; i <= 2; i+=2)
            {

                if (i == 0)
                {
                    firstCell = board[i, i];
                    secondCell = board[i+1, i+1];
                    thirdCell = board[i+2, i+2];
                }
                else
                {
                     firstCell = board[i-2, i];
                     secondCell = board[i-1, i-1];
                     thirdCell = board[i, i-2];
                }
               

                if (firstCell == secondCell && firstCell == thirdCell)
                {
                    return firstCell;
                }
            }

            return 'K';
        }

    }
}
