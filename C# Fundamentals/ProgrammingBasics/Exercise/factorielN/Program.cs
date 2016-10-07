using System;


namespace factorielN
{
    class Program
    {
        static void Main()
        {

            // int n = int.Parse(Console.ReadLine());

            string penis = Console.ReadLine();
            ulong n = ulong.Parse(penis);

            ulong result = 1;

            while (true)
            {
                Console.Write(n);
                if (n == 1)
                {
                    break;
                }
                result *= n;
                n--;
                Console.Write(" * ");

            }
            Console.WriteLine();
            Console.WriteLine(result);

        }
    }
}
