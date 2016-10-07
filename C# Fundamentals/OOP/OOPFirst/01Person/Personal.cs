using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Person
{
    class Personal
    {
        static void Main(string[] args)
        {
            Person Kris = new Person("toshko", 2, "az@sum.tup");
            Console.WriteLine(Kris.ToString());
        }
    }
}
