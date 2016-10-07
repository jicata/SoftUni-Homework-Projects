using System;


namespace Average
{
    class Program
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            double average = (a + b + c) / 3.0;
            Console.WriteLine("{0:00.00}", average);
        }
    }
}
