using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotedStrings
{
    class Program
    {
        static void Main()
        {
            string str1 = "The \"use\" of quotations causes difficulties.";
            string str2 = @"The ""use"" of quotations causes difficulties.";
            Console.WriteLine(str1 + "\n" + str2);
        }
    }
}
