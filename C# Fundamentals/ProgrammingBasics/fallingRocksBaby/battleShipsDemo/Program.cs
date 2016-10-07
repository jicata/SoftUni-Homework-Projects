using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleShipsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] board = new string[10, 10];
            string boardBoarders = new string('-', 30);
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    board[i, j] = " ";
                }
            }
            Console.WriteLine(boardBoarders);
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write("I{0}I", board[i, j]);
                    
                }
                Console.WriteLine();
                Console.WriteLine(boardBoarders);
            }
            Console.WriteLine(string.Join("| |", board));
        }
    }
}
