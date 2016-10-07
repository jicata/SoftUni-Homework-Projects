using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace junk
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = Console.ReadLine();
            StringBuilder finalStage = new StringBuilder(userInput);
            int bombStart = userInput.IndexOf('|');
            int bombEnd = 0;
            int bombDmg = 0;

            while (bombStart != -1)
            {
                bombDmg = 0;
               
                bombEnd = userInput.IndexOf('|', bombStart + 1);
                if (bombEnd <= bombStart)
                {
                    break;
                }
                for (int i = bombStart+1; i < bombEnd; i++)
                {
                    bombDmg += userInput[i];
                    finalStage[i] = '.';
                }
                bombDmg = bombDmg % 10;
                for (int i = bombStart; i >= bombStart-bombDmg && i >= 0; i--)
                {
                    finalStage[i] = '.';
                }
                for (int i = bombEnd; i <= bombEnd+bombDmg && i < finalStage.Length; i++)
                {
                    finalStage[i] = '.';
                }
                bombStart = userInput.IndexOf('|', bombEnd + 1);
                
                

            }
            Console.WriteLine(finalStage);

        }
    }
}
