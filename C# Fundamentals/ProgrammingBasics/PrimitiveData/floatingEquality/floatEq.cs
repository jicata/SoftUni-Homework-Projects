using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace floatingEquality
{
    class floatEq
    {
        static void Main()
        {
            double eps = 0.000001; //for instance

            double a = 5.00000005;
            double b = 5.00000001;

            double diff = Math.Abs(a - b);
            if (diff < eps)
            {
                Console.WriteLine(a + " is equal to " + b);
            }
            else
            {
                Console.WriteLine(a + " is not equal to " + b);
            }
        }
    }
}
