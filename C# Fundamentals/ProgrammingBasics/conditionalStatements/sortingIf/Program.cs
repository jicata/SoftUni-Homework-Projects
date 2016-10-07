using System;


namespace sortingIf
{
    class Program
    {
        static void Main()
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());

            double biggest = a;
            double second = b;
            double smallest = c;

            if (a < b && c < b)
            {
                if (c > a)
                {
                    biggest = b;
                    second = c;
                    smallest = a;
                    Console.WriteLine("{0} {1} {2}", biggest, second, smallest);
                }
                else if (a < c)
                {
                    biggest = b;
                    second = a;
                    smallest = c;
                    Console.WriteLine("{0} {1} {2}", biggest, second, smallest);
                }
            }
            else if (b < a && c < a)
            {
                if (c < b)
                {
                    biggest = a;
                    second = b;
                    smallest = c;
                    Console.WriteLine("{0} {1} {2}", biggest, second, smallest);
                }
                else if (c > b)
                {
                    biggest = a;
                    second = c;
                    smallest = b;
                    Console.WriteLine("{0} {1} {2}", biggest, second, smallest);

                }
            }
            else if (a < c && b < c)
            {
                if (a<b)
                {
                    biggest = c;
                    second = b;
                    smallest = a;
                    Console.WriteLine("{0} {1} {2}", biggest, second, smallest);
                }
                else if (b < a)
                {
                    biggest = c;
                    second = a;
                    smallest = b;
                    Console.WriteLine("{0} {1} {2}", biggest, second, smallest);
                }
            }
        }
    }
}
