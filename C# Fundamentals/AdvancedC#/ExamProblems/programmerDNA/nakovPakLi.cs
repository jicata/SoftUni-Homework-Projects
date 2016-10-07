using System;


class ProgrammerDNA
{
    static void Main()
    {
        //user input
        int sizeInput = int.Parse(Console.ReadLine());
        string inputLetter = Console.ReadLine();
		
        //declaring an ABCD... string
        //and another array to rearrange the initial string into
        string letters = "ABCDEFG";
        char[] scrambledLetters = new char[7];

        //some more count/control variables
        int count = 0;
        int startingLetter = 0;
        int leftEmpty = 3;
        int rightEmpty = 3;
  
        int secondCounter = 0;
        int medium = 7 / 2;
        int thirdCounter = 0;
       
        //find out the starting letter
        for (int i = 0; i < 7; i++)
        {
            string letterString = letters[i].ToString();

            if (letterString == inputLetter)
            {
                startingLetter = i;
            }

        }
        //arrange the array in accordance with the starting letter
        for (int k = 0; k < letters.Length; k++)
        {
            scrambledLetters[0] = letters[startingLetter];
            if (startingLetter + k < letters.Length)
            {
                scrambledLetters[k] = letters[startingLetter + k];
            }
            else
            {
                scrambledLetters[k] = letters[count];
                count++;
            }

            
        }

        // loop through two nested for loops to build up the diamond structure
        // using an extra counter we loop through the array throughout the whole
        // buildup independently of the for loops
        count = 0;
		for (int i = 0; i < sizeInput; i++)
			 {
				 for (int j = 0; j < 7; j++)
				 {
                     if (count >= scrambledLetters.Length)
                     {
                         count = 0;
                     }
					 if  ((i == 0 || i % 7 == 0) && j == 7 / 2)
				     {
					        Console.Write(scrambledLetters[count]);
                            count++;
				     }
                    
                     else if (leftEmpty > j || j > rightEmpty)
                     {
                         Console.Write(".");
                     }
                     else
                     {
                         
                         Console.Write(scrambledLetters[count]);
                         count++;
                         
                     }
				  


				 }
                 
                 Console.WriteLine();
                 
                 thirdCounter++;
                 secondCounter++;
           

                 if (thirdCounter % 7 == 0)
                 {
                     secondCounter = 0;
                     leftEmpty = 3;
                     rightEmpty = 3;
                     continue;
                 }
               
                 
                 if (secondCounter <= medium)
                 {
                     leftEmpty--;
                     rightEmpty++;
                 }

                 else if (secondCounter > medium)
                 {
                     leftEmpty++;
                     rightEmpty--;
                 }
                 
                 
           
            
			 }



    }
}

