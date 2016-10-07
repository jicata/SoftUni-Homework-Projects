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
            char[,] theBoard = new char[15, 15];
  

            int playerRow = 7;
            int playerCol = 7;

 
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
                if (heigansHealthPoints <= 0)
                {
                    heiganAlive = false;
                }

                //1. praim dmg na heigan
                //1.1 dovurshvame magiqta ot predniq hod
                //2. jiv li e heigan?
                //3. kastva magiq AKO E JIV
                //4. ima li murtvi?
                //5. manipulirame player-a
                //6. player-a jiv li e? ako ne -> gg

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

                char damageType = ManipulatePlayer(theBoard, playerRow, playerCol);
                if (damageType != 'S')
                {
                    if (damageType == 'E')
                    {
                        playersHealthPoints -= 6000;
                    }
                    else if (damageType == 'C')
                    {
                        playersHealthPoints -= 3500;
                        isPlagueActive = true;
                    }
                    else if (damageType == 'U')
                    {
                        playerRow -= 1;
                    }
                    else if (damageType == 'R')
                    {
                        playerCol += 1;
                    }
                    else if (damageType == 'D')
                    {
                        playerRow += 1;
                    }
                    else if (damageType == 'L')
                    {
                        playerCol -= 1;
                    }
                }


                if (playersHealthPoints <= 0)
                {
                    playerAlive = false;
                    if (spellName == "Cloud")
                    {
                        causeOfDeath = "Plague Cloud";
                    }
                    else
                    {
                        causeOfDeath = spellName;
                    }
                   
                    break;
                }
                theBoard = new char[15,15];
                
            }

            if (!heiganAlive)
            {
                Console.WriteLine("Heigan: Defeated!");
            }
            else if (heiganAlive)
            {
                Console.WriteLine("Heigan: {0:F}", heigansHealthPoints);
            }

            if (!playerAlive)
            {
                Console.WriteLine("Player: Killed by {0}", causeOfDeath);
            }
            else
            {
                Console.WriteLine("Player: {0}", playersHealthPoints);
            }
            Console.WriteLine("Final position: {0}, {1}", playerRow, playerCol);
        }

        private static char ManipulatePlayer(char[,] theBoard, int playerRow, int playerCol)
        {

            char damageType = 'S';
            bool hasMoved = false;
            if (theBoard[playerRow, playerCol] != '\0')
            {
                //up
                if (IsLegalCell(theBoard, playerRow - 1, playerCol) && theBoard[playerRow - 1, playerCol] == '\0')
                {
                    playerRow = playerRow - 1;
                    damageType = 'U';
                    hasMoved = true;
                }
                //right
                else if (IsLegalCell(theBoard, playerRow, playerCol + 1) && theBoard[playerRow, playerCol + 1] == '\0')
                {
                    playerCol = playerCol + 1;
                    damageType = 'R';
                    hasMoved = true;
                }
                //down
                else if (IsLegalCell(theBoard, playerRow + 1, playerCol) && theBoard[playerRow + 1, playerCol] == '\0')
                {
                    playerRow = playerRow + 1;
                    damageType = 'D';
                    hasMoved = true;
                }
                //left
                else if (IsLegalCell(theBoard, playerRow, playerCol - 1) && theBoard[playerRow, playerCol - 1] == '\0')
                {

                    playerCol = playerCol - 1;
                    damageType = 'L';
                    hasMoved = true;
                }

                if (!hasMoved)
                {
                    if (theBoard[playerRow, playerCol] == 'E')
                    {
                        damageType = 'E';
                    }
                    else
                    {
                        damageType = 'C';
                    }
                }

            }
            return damageType;

        }

        private static void PrintMatrix(char[,] theBoard)
        {
            for (int i = 0; i < theBoard.GetLength(0); i++)
            {
                for (int j = 0; j < theBoard.GetLength(1); j++)
                {
                    Console.Write(theBoard[i,j]);
                }
                Console.WriteLine();
            }
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

            for (int row = spellRow - 1; row <= spellRow + 1; row++)
            {
                for (int col = spellCol - 1; col <= spellCol + 1; col++)
                {
                    if (IsLegalCell(theBoard, row, col))
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
