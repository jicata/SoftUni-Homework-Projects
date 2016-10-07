namespace Heigan_sDance
{
    using System;

    class Program
    {
        static void Main()
        {
            double heigansHealthPoints = 3000000;
            int playersHealthPoints = 18500;
            double playersDamage = double.Parse(Console.ReadLine());
            char [,] theBoard = new char[15,15];
            theBoard[7, 7] = 'P';

            int playerRow = 7;
            int playerCol = 7;

            //1. praim dmg na heigan
            //1.1 dovurshvame magiqta ot predniq hod
            //2. jiv li e heigan?
            //3. kastva magiq AKO E JIV
            //4. ima li murtvi?
            //5. manipulirame player-a
            //6. player-a jiv li e? ako ne -> gg
            bool heiganAlive = true;
            bool playerAlive = true;
            bool isPlagueActive = false;
            string causeOfDeath = "";
            while (true)
            {
                string[] spellArguments = Console.ReadLine().Split();
                string spellName = spellArguments[0];
                int spellRow = int.Parse(spellArguments[1]);
                int spellCol = int.Parse(spellArguments[2]);

                heigansHealthPoints -= playersDamage;
                if (isPlagueActive)
                {
                    playersHealthPoints -= 3500;
                    if (playersHealthPoints <= 0)
                    {
                        causeOfDeath = "Plague Cloud";
                        playerAlive = false;
                    }

                    isPlagueActive = false;
                }
                if (heiganAlive && playerAlive)
                {
                    CastSpell(theBoard, spellName, spellRow, spellCol);
                    
                }
                if (!heiganAlive || !playerAlive)
                {
                    break;
                }

                int[] playerCoordinates = ManipulatePlayer(theBoard, playerRow, playerCol, playersHealthPoints, isPlagueActive);
                playerRow = playerCoordinates[0];
                playerCol = playerCoordinates[1];

                if (playersHealthPoints <= 0)
                {
                    playerAlive = false;
                    causeOfDeath = spellName;
                    break;
                }
               // theBoard = new char[15,15];
                Array.Clear(theBoard,0, 15);
            }
            
            if (!heiganAlive)
            {
                Console.WriteLine("Heigan: Defeated!");
            }
            else if (heiganAlive)
            {
                Console.WriteLine("Heigan: {0}", heigansHealthPoints);
            }

            if (!playerAlive)
            {
                Console.WriteLine("Player: Killed by {0}", causeOfDeath);
            }
            else
            {
                Console.WriteLine("Player: {0}", playersHealthPoints);
            }
            Console.WriteLine("Final position:{0},{1}", playerRow, playerCol);
        }

        private static int[] ManipulatePlayer(char[,] theBoard, int playerRow, int playerCol, int playersHealthPoints, bool isPlagueActive)
        {
            int newPlayerRow = playerRow;
            int newPlayerCol = playerCol;
            bool hasMoved = false;
            if (theBoard[playerRow, playerCol] != ' ') 
            {
                //up
                if (IsLegalCell(theBoard, playerRow - 1, playerCol) && theBoard[playerRow - 1, playerCol] == ' ')
                {
                    newPlayerRow = playerRow - 1;
                    newPlayerCol = playerCol;
                    hasMoved = true;
                }
                //right
                else if (IsLegalCell(theBoard, playerRow, playerCol +1) && theBoard[playerRow , playerCol +1 ] == ' ')
                {
                    newPlayerRow = playerRow;
                    newPlayerCol = playerCol +1;
                    hasMoved = true;
                }
                //down
                else if (IsLegalCell(theBoard, playerRow + 1, playerCol) && theBoard[playerRow + 1, playerCol] == ' ')
                {
                    newPlayerRow = playerRow + 1;
                    newPlayerCol = playerCol;
                    hasMoved = true;
                }
                //left
                else if (IsLegalCell(theBoard, playerRow, playerCol -1) && theBoard[playerRow, playerCol - 1] == ' ')
                {
                    newPlayerRow = playerRow;
                    newPlayerCol = playerCol - 1;
                    hasMoved = true;
                }

                if (!hasMoved)
                {
                    if (theBoard[playerRow, playerCol] == 'E')
                    {
                        playersHealthPoints -= 6000;
                    }
                    else
                    {
                        playersHealthPoints -= 3500;
                        isPlagueActive = true;
                    }
                }
                

            }
            int[] playerCoordinates = new int[2];
            playerCoordinates[0] = playerRow;
            playerCoordinates[1] = playerCol;
            return playerCoordinates;

        }

        private static void CastSpell(char[,] theBoard, string spellName, int spellRow, int spellCol)
        {
            char spellSymbol = ' ';
            if (spellName == "Eruption")
            {
                spellSymbol = 'E';
            }
            else
            {
                spellSymbol = 'C';
            }
            
            for (int row = spellRow -1; row < spellRow+1; row++)
            {
                for (int col = spellCol-1; col < spellCol+1; col++)
                {
                    if (IsLegalCell(theBoard,row, col))
                    {
                        theBoard[row, col] = spellSymbol;
                    }
                }
            }
        }

        private static bool IsLegalCell(char[,] board, int row, int col)
        {
            bool isLegal = false;
            if (row >= 0 && row < board.GetLength(0) && col >= 0 && col < board.GetLength(1))
            {
                isLegal = true;
            }
            return isLegal;
        }
    }
}
