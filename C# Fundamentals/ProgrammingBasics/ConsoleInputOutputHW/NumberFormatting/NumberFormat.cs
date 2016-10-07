using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberFormatting
{
    class NumberFormat
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            string aBin = Convert.ToString(a, 2);
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            Console.WriteLine("{0,-10:X} {1} {2,10:0.00} {3,-10:0.000}", a, aBin.PadLeft(10, '0'), b, c);

           
        }
    }
}
