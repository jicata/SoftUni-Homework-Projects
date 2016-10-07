using System;


namespace ma3x
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    Console.Write(j+i);
                }
                Console.WriteLine();
            }
        }
    }
}
