using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collectTheCoins
{
    class uberMario
    {
        static void Main()
        {
            List<List<char>> myBoard = new List<List<char>>();
            

            for (int i = 0; i < 4; i++)
            {
                myBoard.Add(new List<char>());

                string rawUserInput = Console.ReadLine();
                char[] userInput = rawUserInput.Select(x => x).ToArray();
                for (int j = 0; j < userInput.Length; j++)
                {
                    myBoard[i].Add(userInput[j]);
                }
               
                
            }
            int row = 0;
            int col = 0;
            int wallCounter = 0;
            int moneyCount = 0;
            var currentPos = myBoard[row][col];
            var lastPos = currentPos;
            string rawMovementInput = Console.ReadLine();
            char[] movementInput = rawMovementInput.Select(x => x).ToArray();

            foreach (char direction in movementInput)
            {
                if(direction == '>')
                {
                    row++;
                    if(row >= myBoard.Count)
                    {
                        row--;
                        wallCounter++;
                        continue;
                    }
                }
                else if(direction == '<')
                {
                    row--;
                    if(row < 0)
                    {
                        row++;
                        wallCounter++;
                        continue;
                    }
                }
                else if(direction == '^')
                {
                    col++;
                    if (col > myBoard[row].Count)
                    {
                        col--;
                        wallCounter++;
                        continue;
                    }
                }
                else if(direction == 'v')
                {
                    col--;
                    if (col < 0)
                    {
                        wallCounter++;
                        col--;
                        continue;
                    }
                }
                
                if (row < myBoard.Count && col < myBoard[row].Count)
                {
                    currentPos = myBoard[row][col];
                    if (currentPos == '$' && currentPos !=lastPos)
                    {
                        moneyCount++;
                    }
                    lastPos = currentPos;
                }
               
                

            }

            Console.WriteLine("Coins collected: {0}", moneyCount);
            Console.WriteLine("Wallbangs: {0}", wallCounter);
            //Console.WriteLine(currentPos);
            //Console.WriteLine();
            //foreach (var item in myBoard)
            //{
            //    foreach (var penis in item)
            //    {
            //        Console.Write(penis);
            //    }
            //    Console.WriteLine();
            //}
        }
    }
}
