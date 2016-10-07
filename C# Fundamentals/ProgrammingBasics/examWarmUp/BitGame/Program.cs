using System;


namespace BitGame
{
    class Program
    {
        static void Main()
        {
            uint n = uint.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            while (input !="Game Over!")
            {
                uint newNumber = 0;
                if (input == "Even")
                {
                    n >>= 1;
                }
                for (int i = 0; n > 0; i++)
                {
                    newNumber |= (n & 1) << i;
                    n >>= 2;
                }
                input = Console.ReadLine();
                n = newNumber;
            }
            Console.Write(n);
            int count = 0;
            while (n>0)
            {
                uint bit = n & 1;
                if (bit == 1) count++;
                n >>= 1;
            }
            Console.WriteLine(" {0} ", n);
        }
    }
}
