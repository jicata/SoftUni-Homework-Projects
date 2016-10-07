using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakovTheAlphabetLover
{
    class makeLoveNotProgramming
    {
        static void Main()
        {
            string[] userInput = Console.ReadLine().Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
            string thisParticularOne = string.Empty;
            double theNumber = 0;
            char firstLetter = ' ';
            char secondLetter = ' ';
            int indexOfFirst = 0;
            int indexOfSecond = 0;

            
            double grandTotal = 0;
            
            for (int i = 0; i < userInput.Length; i++)
			{
                thisParticularOne = userInput[i];

                if (thisParticularOne.Length > 3)
                {
                    StringBuilder getTheNumber = new StringBuilder(thisParticularOne);
                    getTheNumber.Remove(0, 1);
                    getTheNumber.Length = getTheNumber.Length - 1;



                    theNumber = double.Parse(getTheNumber.ToString());

                    firstLetter = thisParticularOne[0];
                    secondLetter = thisParticularOne[thisParticularOne.Length - 1];
                }
                else
                {
                    theNumber = double.Parse(thisParticularOne[1].ToString());
                    firstLetter = thisParticularOne[0];
                    secondLetter = thisParticularOne[thisParticularOne.Length - 1];
                }

                indexOfFirst = (int)firstLetter % 32;
                indexOfSecond = (int)secondLetter % 32;
                

                if (char.IsUpper(thisParticularOne[0]))
                {
                    theNumber /= indexOfFirst;
                }
                else
                {
                    theNumber  *= indexOfFirst;
                }

                if(char.IsUpper(thisParticularOne[thisParticularOne.Length-1]))
                {
                    theNumber -= indexOfSecond;
                }
                else
                {
                 
                    theNumber += indexOfSecond;
                }
                grandTotal += theNumber;
                
                



			}
            
            Console.WriteLine("{0:0.00}",grandTotal);
            //z2147483647z
        }
    }
}
