using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _01.Series_Of_Letters
{
    class letras
    {
        static void Main()
        {
            Regex regex = new Regex("(.)\\1+");
            var str = Console.ReadLine();

            Console.WriteLine(regex.Replace(str, "$1"));
        }
    }
}
