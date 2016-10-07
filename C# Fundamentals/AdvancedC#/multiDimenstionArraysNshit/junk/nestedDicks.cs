using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace terrositsWin
{
    class de_dustII
    {
        static void Main()
        {
            string test = Console.ReadLine();
            // int bombStart = test.IndexOf('|');
            char[] allTheLetters = test.ToCharArray();
            List<int> tempStorage = new List<int>();
            int sum = 0;

            int insideCounter = 0;
            int startIndex = 0;
            int bombLength = 0;
            int blastDmg = 0;
            int leftBlastIndex = 0;
            int rightBlastIndex = 0;
            string fallout = string.Empty;
            string leftFallout = string.Empty;
            string rightFallout = string.Empty;
            StringBuilder workInProgress = new StringBuilder(test);

            for (int i = 0; i < allTheLetters.Length; i++)
            {

                if (allTheLetters[i] == '|')
                {

                    startIndex = i;
                    while (allTheLetters[i + 1] != '|')
                    {
                        insideCounter++;
                        i++;
                        sum += allTheLetters[i];
                    }

                    //set bomb values
                    blastDmg = sum % 10;
                    i = startIndex + insideCounter + 1;
                    bombLength = i - startIndex + 1;


                    //set explosion values

                    leftBlastIndex = startIndex - blastDmg;
                    rightBlastIndex = bombLength + blastDmg * 2;
                    if (leftBlastIndex < 0)
                    {
                        leftBlastIndex = 0;
                    }
                    if (rightBlastIndex > workInProgress.Length)
                    {
                        rightBlastIndex = workInProgress.Length;
                    }

                    //cut the string
                    workInProgress.Remove(leftBlastIndex, rightBlastIndex);
                    if (leftBlastIndex > 0 && rightBlastIndex < workInProgress.Length)
                    {
                        fallout = new string('.', rightBlastIndex);
                    }
                    else if (leftBlastIndex == 0 && rightBlastIndex < workInProgress.Length)
                    {
                        leftFallout = new string('.', startIndex);
                        rightFallout = new string('.', blastDmg + bombLength);
                        fallout = leftFallout + rightFallout;
                    }
                    else if (leftBlastIndex > 0 && rightBlastIndex > workInProgress.Length)
                    {
                        leftFallout = new string('.', bombLength + blastDmg);
                        rightFallout = new string('.', workInProgress.Length - startIndex + bombLength);
                        fallout = leftFallout + rightFallout;
                    }

                    workInProgress.Insert(leftBlastIndex, fallout);

                    //resest counters etc.
                    insideCounter = 0;
                    sum = 0;


                }
            }
            Console.WriteLine(workInProgress);
            //for (int i = 0; i < tempStorage.Count; i++)
            //{
            //    Console.WriteLine(tempStorage[i]);
            //}
        }
    }
}
