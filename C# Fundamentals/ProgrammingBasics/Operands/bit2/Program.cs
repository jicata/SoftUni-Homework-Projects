using System;


namespace bit2
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            Console.WriteLine(Convert.ToString(n, 2).PadLeft(16, '0'));
            int findIt = n >> p;
            int foundIt = findIt & 1;
            Console.WriteLine(foundIt);
        }
    }
}
