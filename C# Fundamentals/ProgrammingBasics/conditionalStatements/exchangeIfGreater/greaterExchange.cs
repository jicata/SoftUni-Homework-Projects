using System;

namespace exchangeIfGreater
{
    class greaterExchange
    {
        static void Main()
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = 0;
            if (a > b)
            {
                
                c = a;
                a = b;
                Console.WriteLine("{0} {1}", a, c);
            }
            else
            {
                Console.WriteLine("{0} {1}", a , b);
            }
        }
    }
}
