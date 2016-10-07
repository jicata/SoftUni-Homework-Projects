using System;

class golqm
{
    public static void Main()
    {
        Console.Write("Enter a positive integer number: ");
        uint number = uint.Parse(Console.ReadLine());
        int divider = 2;
        uint maxDivider = (uint) Math.Sqrt(number);
        bool prime = true;
        while (prime && (divider <= maxDivider))
        {
            if (number % divider == 0)
            {
                prime = false;
            }
            divider++;
        }
        Console.WriteLine("Is {0} a prime now? {1}", number, prime);
    }
}


