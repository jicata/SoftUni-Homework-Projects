using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.RadioAtractive_Bunnies
{
    class Program
    {
        static void Main()
        {
            string[] matrixCoordinates = Console.ReadLine().Split();
            int rows = int.Parse(matrixCoordinates[0]);
            int cols = int.Parse(matrixCoordinates[1]);

            char[,] board = new char[rows,cols];
            int currentPlayerRow = 0;
            int currentPlayerCol = 0;
            bool win = false;
            bool dead = false;
            bool moved = false;
            for (int i = 0; i < rows; i++)
            {
                string boardRowFill = Console.ReadLine();
                for (int j = 0; j < boardRowFill.Length; j++)
                {
                    board[i, j] = boardRowFill[j];
                }
            }
            string moves = Console.ReadLine();
            
            for (int i = 0; i < moves.Length; i++)
            {
                for (int a = 0; a < rows; a++)
                {
                    for (int b = 0; b < cols; b++)
                    {
                        if (board[a,b] == 'P')
                        {
                            currentPlayerRow = a;
                            currentPlayerCol = b;
                        }
                    }
                }


                if (Win(board, currentPlayerRow, currentPlayerCol, moves[i]))
                {
                    board[currentPlayerRow, currentPlayerCol] = '.';
                    win = true;

                }
                else if (Dead(board, currentPlayerRow, currentPlayerCol, moves[i]))
                {
                    board[currentPlayerRow, currentPlayerCol] = '.';
                    dead = true;
                }


                else
                {
                    MovePlayer(board, currentPlayerRow, currentPlayerCol, moves[i]);
                    moved = true;
                    for (int a = 0; a < rows; a++)
                    {
                        for (int b = 0; b < cols; b++)
                        {
                            if (board[a, b] == 'P')
                            {
                                currentPlayerRow = a;
                                currentPlayerCol = b;
                            }
                        }
                    }

                }
                
                for (int j = 0; j < rows; j++)
                {
                    for (int k = 0; k < cols; k++)
                    {
                        if (board[j,k] == 'B')
                        {
                            PrintRabbit(board, j, k);
                        }
                        
                    }
                }
                
                
                for (int q = 0; q < rows; q++)
                {
                    for (int l = 0; l < cols; l++)
                    {
                        if (board[q,l] =='N')
                        {
                            board[q,l] = 'B';
                        }
                    }
                }
                if(moved)
                {
                    if (board[currentPlayerRow,currentPlayerCol] == 'B')
                    {
                        dead = true;
                    }
                }
               
                if(win)
                {
                    for (int g = 0; g < rows; g++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            Console.Write(board[g, j]);
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("won: {0} {1}", currentPlayerRow, currentPlayerCol);
                    break;
                }
                    
                
                else if(dead)
                {
                    for (int g = 0; g < rows; g++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            Console.Write(board[g, j]);
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("dead: {0} {1}", currentPlayerRow, currentPlayerCol);
                    break;
                }
                
               
                
                
                

            }
            

        }
        public static void PrintRabbit(char[,] matrix, int currentRow, int currentCol)
        {
            int leftCol = Math.Max(currentCol - 1, 0);
            int rightCol = Math.Min(currentCol + 1, matrix.GetLength(1)-1);
            int topRow = Math.Max(currentRow - 1, 0);
            int botRow = Math.Min(currentRow + 1, matrix.GetLength(0)-1);
            if ((matrix[currentRow,leftCol] == '.' || matrix[currentRow,leftCol] == 'P'))
            {
                matrix[currentRow, leftCol] = 'N';
            }
            if(matrix[currentRow,rightCol] == '.' || matrix[currentRow, rightCol] == 'P')
            {
                matrix[currentRow, rightCol] ='N';
            }
            if(matrix[topRow, currentCol] == '.' || matrix[topRow, currentCol] == 'P')
            {
                matrix[topRow, currentCol] = 'N';
            }
            if(matrix[botRow, currentCol] == '.' || matrix[botRow, currentCol] == 'P')
            {
                matrix[botRow, currentCol] = 'N';
            }
        }
        public static void MovePlayer(char[,] board, int currentRow, int currentCol, char direction)
        {
            
            if (direction == 'U')
            {
               
                    board[currentRow - 1, currentCol] = 'P';
                    board[currentRow, currentCol] = '.';
                
            }
            if(direction =='D')
            {
                
                
                    board[currentRow + 1, currentCol] = 'P';
                    board[currentRow, currentCol] = '.';
                
            }
            if (direction == 'L')
            {

               
                    board[currentRow, currentCol - 1] = 'P';
                    board[currentRow, currentCol] = '.';
                
            }
            if (direction == 'R')
            {
                
                
                    board[currentRow, currentCol+1] = 'P';
                    board[currentRow, currentCol] = '.';
                
            }

        }
        public static bool Win(char[,] board, int currentRow, int currentCol, char direction)
        {
            bool win = false;
            if (direction == 'U')
            {
                if(currentRow-1 < 0)
                {
                    win = true;
                    return win;
                }
            }
            if(direction =='D')
            {
                if (currentRow +1 >= board.GetLength(0))
                {
                    win = true;
                    return win;
                }
               
            }
            if (direction == 'L')
            {

                if (currentCol - 1 < 0)
                {
                    win = true;
                    return win;
                }
                
            }
            if (direction == 'R')
            {
                if (currentCol + 1 >= board.GetLength(1))
                {
                    win = true;
                    return win;
                }
            }
            return win;
        }
        public static bool Dead(char[,] board, int currentRow, int currentCol, char direction)
        {
            bool dead = false;
            
            if (direction == 'U')
            {
                if (board[currentRow - 1, currentCol] == 'B')
                {
                    dead = true;
                    return dead;
                }
            }
            if (direction == 'D')
            {
                if (board[currentRow + 1, currentCol] == 'B' )
                {
                    dead = true;
                    return dead;
                }
            }
            if (direction == 'L')
            {
                if (board[currentRow, currentCol - 1] == 'B' )
                {
                    dead = true;
                    return dead;
                }
            }
            if (direction == 'R')
            {
                if (board[currentRow, currentCol + 1] == 'B') 
                {
                    dead = true;
                    return dead;
                }
            }
            return dead;
        }
        
    }
}
