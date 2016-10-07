using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirclePerArea
{
    class CirleAround
    {
        static void Main()
        {
            double r = double.Parse(Console.ReadLine());
            double pi = Math.PI;
            double area = Math.Pow(r, 2) * pi;
            double perimeter = 2 * (pi * r);
            Console.WriteLine("The area of the circle is: {0:0.00}", area);
            Console.WriteLine("The perimeter of the circle is: {0:0.00}", perimeter);
        }
    }
}
