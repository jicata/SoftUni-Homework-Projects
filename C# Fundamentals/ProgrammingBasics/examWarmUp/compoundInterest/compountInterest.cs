using System;
using System.Numerics;


namespace compoundInterest
{
    class compountInterest
    {
        static void Main()
        {
            double priceOfProduct = double.Parse(Console.ReadLine());
            int termInYears = int.Parse(Console.ReadLine());
            double bankInterest = double.Parse(Console.ReadLine());
            double friendsInterest = double.Parse(Console.ReadLine());

            double bankLoan = priceOfProduct * (Math.Pow(1 + bankInterest, termInYears));
            double friendsLoan = priceOfProduct *(1 + friendsInterest);

            if (bankLoan == friendsLoan || friendsLoan < bankLoan)
            {
                Console.WriteLine("{0:F2} Friend", friendsLoan);
            }
            else 
            {
                Console.WriteLine("{0:F2} Bank", bankLoan);
            }
            
        }
    }
}
