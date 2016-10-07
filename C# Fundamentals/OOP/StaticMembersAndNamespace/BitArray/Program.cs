using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitArray
{
    class Program
    {
        static void Main(string[] args)
        {
            BitArray bitcheta = new BitArray(100000);
            bitcheta[99999] = 1;
            bitcheta[2130] = 1;
            //runs rather slow at max lenght
            Console.WriteLine(bitcheta);
        }
    }
}
