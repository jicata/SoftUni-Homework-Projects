using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicode
{
    class UniCode
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            char shano = '\u00A9';
            Console.WriteLine(shano);
        }
    }
}
