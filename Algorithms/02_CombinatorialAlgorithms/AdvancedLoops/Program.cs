namespace AdvancedLoops
{
    using System;
    using System.Diagnostics;

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    int number = row + col + 1;
                    if (number > n)
                    {
                        number = 2*n - number;
                    }
                    Console.Write(number + " ");
                }
                Console.WriteLine();
            }
            
        }
    }
}
