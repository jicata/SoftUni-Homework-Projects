using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByTheCake
{
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            string byTheCakeHtml =
                File.ReadAllText(
                    @"D:\xampp\cgi-bin\ByTheCakeIndex.html");
            Console.Write("Content-Type: text/html image/jpeg \n\n");                           
            Console.Write(byTheCakeHtml);
        }
    }
}
