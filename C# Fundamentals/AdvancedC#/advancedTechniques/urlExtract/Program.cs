using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urlExtract
{
    class Program
    {
        static void Main()
        {
            string rawString = Console.ReadLine();
            var links = rawString.Split("\t\n ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Where(s => s.StartsWith("http://") || s.StartsWith("www.") || s.StartsWith("https://"));
            Console.WriteLine();
            foreach (string s in links)
                Console.WriteLine(s); 
        }
    }
}
