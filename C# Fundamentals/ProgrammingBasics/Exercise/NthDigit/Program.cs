using System;


namespace NthDigit
{
    class Program
    {
        static void Main()
        {
            double number = double.Parse(Console.ReadLine());
            double n = double.Parse(Console.ReadLine());
            double nDigit = (number / Math.Pow(10, n-1)) % 10;
            Console.WriteLine(Math.Floor(nDigit));

        }
    }
}
