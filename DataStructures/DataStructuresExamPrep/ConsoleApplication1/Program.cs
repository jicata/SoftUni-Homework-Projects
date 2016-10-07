namespace ConsoleApplication1
{
    using System;

    class Program
    {
        static void Main()
        {
            var center = new ShoppingCenter();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(center.ProcessCommand(Console.ReadLine()));
                Console.WriteLine();
            }
        }
    }
}
    