using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fibonacci
{
    class fibonacci
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            if (n == 1) Console.WriteLine(0);
            else
            {
                int first = 0;
                int second = 1;
                Console.Write(first + " ");
                Console.Write(second + " ");
                int third = 0;
                for (int i = 2; i < n; i++)
                {
                    third = first + second;
                    Console.Write(third + " ");
                    first = second;
                    second = third;
                }
            }

        }
    }
}
