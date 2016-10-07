using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lastDigitOfANumma
{
    class lastDigit
    {
        static void Main()
        {
            int gimmeAnumma = int.Parse(Console.ReadLine());
            Console.WriteLine(LastDigitMan(gimmeAnumma));

        }
        public static string LastDigitMan(int number)
        {
            string theLastDigit = (number % 10).ToString();
            switch (theLastDigit)
            {
                case "1": theLastDigit = "one";
                    break;
                case "2": theLastDigit = "two";
                    break;
                case "3": theLastDigit = "three";
                    break;
                case "4": theLastDigit = "four";
                    break;
                case "5": theLastDigit = "five";
                    break;
                case "6": theLastDigit = "six";
                    break;
                case "7": theLastDigit = "seven";
                    break;
                case "8": theLastDigit = "eight";
                    break;
                case "9": theLastDigit = "nine";
                    break;
                default: theLastDigit = "zero";
                    break;

            }

            return theLastDigit;
        }
    }
}
