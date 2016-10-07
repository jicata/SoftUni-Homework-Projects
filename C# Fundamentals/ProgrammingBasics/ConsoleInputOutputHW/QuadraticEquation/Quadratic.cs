using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticEquation
{
    class Quadratic
    {
        static void Main()
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            //double sqrtpart = (b * b) - (4 * a * c);
            double sqrtpart = (b * b) - (4 * a * c);
            double x1 = ((-1) * b + Math.Sqrt(sqrtpart)) / (2 * a);
            double x2 = ((-1) * b - Math.Sqrt(sqrtpart)) / (2 * a);
            Console.WriteLine("The real roots are {0} and {1}", x1, x2);
        }
    }
}
