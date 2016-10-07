using System;


namespace decimalToBinary
{
    class Program
    {
        static void Main()
        {
            string penis = Console.ReadLine();
            int hui = Convert.ToInt32(penis);
            const int mask = 1;

            var binary = string.Empty;
            while (hui > 0)
            {
                // Logical AND the number and prepend it to the result string
                binary = (hui & 1) + binary;
                hui = hui >> 1;
            }
            Console.WriteLine(binary);
        }
    }
}
