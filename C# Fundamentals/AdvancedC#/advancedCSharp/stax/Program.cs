using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stax
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> penis = new Queue<string>();
            penis.Enqueue("Pesho");
            penis.Enqueue("Ani");
            penis.Enqueue("Didi");
            while (penis.Count>0)
            {
                Console.WriteLine(penis.Dequeue());
            }
        }
    }
}
