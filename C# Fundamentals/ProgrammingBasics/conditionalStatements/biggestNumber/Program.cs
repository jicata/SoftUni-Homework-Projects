using System;


namespace biggestNumber
{
    class Program
    {
        static void Main()
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());

            if (a > b)
            {
                if (a > c)
                {
                    Console.WriteLine(a);
                }
            }
            if (b > a)
            {
                if (b > c)
                    Console.WriteLine(b);
            }
            if (c > a)
            {
                if (c > b)
                    Console.WriteLine(c);
            }
            
        }
    }
}
