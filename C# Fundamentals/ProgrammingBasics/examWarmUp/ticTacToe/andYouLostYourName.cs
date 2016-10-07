using System;


namespace ticTacToe
{
    class andYouLostYourName
    {
        static void Main()
        {
            double[,] ticTacBoard = new double[3, 3];

            double count = 0;
            double actualCounter = 0;

            int userX = int.Parse(Console.ReadLine());
            int userY = int.Parse(Console.ReadLine());
           
            double userInput = double.Parse(Console.ReadLine());


            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    ticTacBoard[i, j] = userInput;
                    userInput++;
                    count++;

                    if (ticTacBoard[i, j] == ticTacBoard[userY, userX])
                    {
                        actualCounter = count;
                    }

                   
                }
               
            }
            userInput -= 9;
            
            double index = 0;
            double value = 0;
            double result = 0;
            


            value = ticTacBoard[userY, userX];
            index = (value - userInput) + 1;
            

            result = Math.Pow(value, index);
            
            long actualResult = Convert.ToInt64(result);
            Console.WriteLine(actualResult);
            







        }
    }
}
