using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    using System.Runtime.CompilerServices;

    class Program
    {
        static void Main(string[] args)
        {
            var kur = RemovedNumbers.removNb(100);
            foreach (var longse in kur)
            {
                Console.WriteLine(string.Join(", ", longse));
            }
        }
    }
}
