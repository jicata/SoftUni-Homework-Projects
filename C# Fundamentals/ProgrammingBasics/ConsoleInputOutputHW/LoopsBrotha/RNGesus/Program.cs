using System;


namespace RNGesus
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int min = int.Parse(Console.ReadLine());
            int max = int.Parse(Console.ReadLine());
            Random r = new Random();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(r.Next(min,max)); 
            }

        }
    }
}
