using System;


namespace PrimeNumberCheck
{
    class Program
    {
        static void Main()
        {
            bool isPrime = false;
            
            Console.Write("Enter a number: ");
            int theNum = int.Parse(Console.ReadLine());
            if (theNum < 3)
            {
                if (theNum == 2)
                {
                    isPrime = true;
                    Console.WriteLine(isPrime);
                }
                else
                {
                    Console.WriteLine(isPrime);
                }

            }
            else
            {
                if (theNum % 2 == 0)
                {
                    Console.WriteLine(isPrime);
                }
                else
                {
                    int div;
                    for (div = 3; theNum % div != 0; div += 2)
                        ;
                    if (div == theNum)
                    {
                        isPrime = true;
                        Console.WriteLine(isPrime);
                    }
                    else
                    {
                        Console.WriteLine(isPrime);
                    }

                }
            }

            Console.ReadLine();

        }
    }
}
