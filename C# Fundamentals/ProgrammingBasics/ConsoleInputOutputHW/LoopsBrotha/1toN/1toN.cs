using System;


namespace _1toN
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int miniCounter = 1;

            while (miniCounter < n)
            {
                Console.Write(miniCounter+ " ");
                miniCounter++;


            }
            Console.WriteLine();
        }
    }
}
