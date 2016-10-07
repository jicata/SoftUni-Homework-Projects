using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nullables
{
    class Program
    {
        static void Main()
        {
            int? num = null;
            num = num + 42;
            num = 10;
            Console.WriteLine(num);
        }
    }
}
