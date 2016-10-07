using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableOperations
{
    class NullOp
    {
        static void Main()
        {
            int? a = null;
            double? b = null;
            Console.WriteLine(a + b);
            Console.WriteLine(a + 10);

        }
    }
}
