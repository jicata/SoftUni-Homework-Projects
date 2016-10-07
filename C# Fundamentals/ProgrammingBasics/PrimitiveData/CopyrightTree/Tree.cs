using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyrightTree
{
    class Tree
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            char CpyRight = '\u00A9';
            Console.WriteLine("    " + CpyRight + "   ");
            Console.WriteLine("  " + CpyRight + "   " + CpyRight);
            Console.WriteLine(" " + CpyRight + "  " + CpyRight + "  " + CpyRight);
            Console.WriteLine("" + CpyRight + "  " + CpyRight + "  " + CpyRight + "  " + CpyRight);
        }
    }
}