using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main()
        {
            int n = Console.Read();
            int[] fib = { 0, 1 };
            for (int i = 2; i<= n; i++)
            {
                fib.append(fib[n - 1] + fib[n - 2]);
            }
        }
    }
}
