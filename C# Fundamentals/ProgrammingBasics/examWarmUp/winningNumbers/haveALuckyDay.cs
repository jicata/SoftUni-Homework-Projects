using System;

namespace winningfirstNumber
{
    class haveALuckyDay
    {
        static void Main()
        {
            string s = Console.ReadLine();
            string lowerS = s.ToLower();
            char[] alphabetValue = new char[26];
            int count = 0;
            int extraCount = 1;
            int lettersValue = 0;

            for (char letter = 'a'; letter <= 'z'; letter++)
            {
                
                alphabetValue[count] = letter;
                
                
                count++;
            }
            foreach (char ch in lowerS)
            {
                foreach(char letter in alphabetValue)
                {
                    if(ch == letter)
                    {
                        
                        lettersValue += extraCount;
                    }
                    extraCount++;
                }
                extraCount = 1;
            }
        
            int firstThreeDigits = 100;
            int secondThreeDigits = 100;
            bool flagOne = false;
            bool flagTwo = false;

            for (int i = 111; i <= 999; i++)
            {
                firstThreeDigits = i;
                string firstNumber = firstThreeDigits.ToString();
                int firstNum = Convert.ToInt32(Convert.ToString(firstNumber[0]));
                int secondNum = Convert.ToInt32(Convert.ToString(firstNumber[1]));
                int thirdNum = Convert.ToInt32(Convert.ToString(firstNumber[2]));
                if (firstNum*secondNum*thirdNum == lettersValue)
                {
                   flagOne=true;
                    for (int j = 111; j <= 999; j++)
                    {
                        flagTwo = true;
                        secondThreeDigits = j;
                        string secondNumber = secondThreeDigits.ToString();
                        int numOne = Convert.ToInt32(Convert.ToString(secondNumber[0]));
                        int numTwo = Convert.ToInt32(Convert.ToString(secondNumber[1]));
                        int numThree = Convert.ToInt32(Convert.ToString(secondNumber[2]));
                        if (numOne * numTwo * numThree == lettersValue)
                        {
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
