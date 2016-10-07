using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariableExchange
{
    class Exchange
    {
        static void Main()
        {
            int a = 5;
            int b = 10;
            Console.WriteLine(a + ", " + b);
            int c = a;
            a = b;
            b = c;
            Console.WriteLine(a + ", " + b);
        }
    }
}
