using System;
using System.Collections.Generic;

namespace bit1
{
    class bit1
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            int p = 3;
            int findIt = num >> p;
            int foundIt = findIt & 1;
            Console.WriteLine(foundIt);
            Console.WriteLine(Convert.ToString(num, 2).PadLeft(16, '0'));
        }
    }
}
