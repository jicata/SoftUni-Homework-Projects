using System;
using System.Numerics;

namespace petarsGame
{
    class peshoBrat
    {
        static void Main()
        {
            ulong startingNumber = ulong.Parse(Console.ReadLine());
            ulong endingNumber = ulong.Parse(Console.ReadLine());
            string petarNapushen = Console.ReadLine();
            

            BigInteger sum = 0;
            string sumString = "";
            

            for (ulong i = startingNumber; i < endingNumber ; i++)
            {
                if (i % 5 == 0)
                {
                    sum += i;
                }
                else
                {
                    sum += i % 5;
                }
            }


            string theDigit = "";
        

            if (sum % 2 == 0)
            {

                theDigit = sum.ToString()[0].ToString();

            }
            else
            {
                
                theDigit = sum.ToString()[sum.ToString().Length - 1].ToString();
            }
            Console.WriteLine(sum.ToString().Replace(theDigit, petarNapushen));


            
        }
    }
}
