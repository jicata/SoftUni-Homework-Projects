using System;


namespace bit4
{
    class bit4
    {
        static void Main()
        {
            int findIt, foundIt;
            Console.WriteLine("Enter a number: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Convert.ToString(n, 2).PadLeft(16, '0'));
            Console.WriteLine("Enter a position: ");
            int p = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter another number (0 or 1): ");
            int v = int.Parse(Console.ReadLine());
            if (v == 0)
            {
                findIt = ~(1 << p);
                foundIt = findIt & n;
                Console.WriteLine(Convert.ToString(foundIt, 2).PadLeft(16, '0'));
            }
            else if (v == 1)
            {
                findIt = 1 << p;
                foundIt = findIt | n;
                Console.WriteLine(Convert.ToString(foundIt, 2).PadLeft(16, '0'));
            }
        }
    }
}
