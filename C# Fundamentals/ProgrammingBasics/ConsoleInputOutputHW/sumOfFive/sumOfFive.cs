using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sumOfFive
{
    class sumOfFive
    {
        static void Main()
        {
            //int[] input = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            Console.WriteLine("Enter 5 numbers separated by space");
            string[] tokens = Console.ReadLine().Split();
            double a = double.Parse(tokens[0]);
            double b = double.Parse(tokens[1]);
            double c = double.Parse(tokens[2]);
            double d = double.Parse(tokens[3]);
            double e = double.Parse(tokens[4]);
            double sum = Math.Abs(a + b + c + d + e);
            Console.WriteLine(sum);
        }
    }
}
