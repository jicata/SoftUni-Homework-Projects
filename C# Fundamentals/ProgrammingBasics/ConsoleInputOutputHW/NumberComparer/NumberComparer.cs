using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberComparer
{
    class NumberComparer
    {
        static void Main()
        {
            Console.WriteLine("Finding the greater number without if statement!");
            Console.WriteLine("Enter the first number:");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the second number:");
            double b = double.Parse(Console.ReadLine());
            double c = Math.Max(a, b);
            Console.WriteLine("The greater number is: {0}", c);
        }
    }
}
