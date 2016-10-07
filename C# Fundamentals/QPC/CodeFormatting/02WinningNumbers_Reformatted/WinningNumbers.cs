using System;

namespace _02WinningNumbers_Reformatted
{
    class WinningNumbers
    {
        static void Main()
        {
            string rawUserInput = Console.ReadLine();
            string userInputToLower = rawUserInput.ToLower();

            char[] alphabetValue = new char[26];

            int counter = 0;
            int extraCounter = 1;
            int totalLettersValue = 0;

            for (char letter = 'a'; letter <= 'z'; letter++)
            {

                alphabetValue[counter] = letter;
                counter++;
            }
            foreach (char ch in userInputToLower)
            {
                foreach (char letter in alphabetValue)
                {
                    if (ch == letter)
                    {
                        totalLettersValue += extraCounter;
                    }
                    extraCounter++;
                }
                extraCounter = 1;
            }

            int firstThreeDigits;
            int secondThreeDigits;
            bool flagOne = false;
            bool flagTwo = false;

            for (int i = 111; i <= 999; i++)
            {
                firstThreeDigits = i;
                string firstNumber = firstThreeDigits.ToString();

                int firstDigit = Convert.ToInt32(Convert.ToString(firstNumber[0]));
                int secondDigit = Convert.ToInt32(Convert.ToString(firstNumber[1]));
                int thirdDigit = Convert.ToInt32(Convert.ToString(firstNumber[2]));

                if (firstDigit * secondDigit * thirdDigit == totalLettersValue)
                {
                    flagOne = true;
                    for (int j = 111; j <= 999; j++)
                    {


                        secondThreeDigits = j;
                        string secondNumber = secondThreeDigits.ToString();

                        int digitOne = Convert.ToInt32(Convert.ToString(secondNumber[0]));
                        int digitTwo = Convert.ToInt32(Convert.ToString(secondNumber[1]));
                        int digitThree = Convert.ToInt32(Convert.ToString(secondNumber[2]));

                        if (digitOne * digitTwo * digitThree == totalLettersValue)
                        {
                            flagTwo = true;
                            Console.WriteLine("{0}-{1}", firstThreeDigits, secondThreeDigits);
                        }
                    }
                }


            }
            if (!flagOne && !flagTwo)
            {
                Console.WriteLine("No");
            }

        }
    }
}
