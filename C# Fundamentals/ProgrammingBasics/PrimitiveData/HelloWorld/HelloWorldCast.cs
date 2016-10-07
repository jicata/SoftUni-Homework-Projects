using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class HelloWorldCast
    {
        static void Main()
        {
            string hi = "Hello, ";
            string wrld = "world!";
            object hiWrld = hi + wrld;
            string HelloWorld = (string) hiWrld;
            Console.WriteLine(HelloWorld);
        }
    }
}
