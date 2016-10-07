using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dividebleInterval
{
    class divide
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            List<int> p = new List<int>();
            Console.WriteLine("The numbers between {0} and {1} divisible by 5 are: ", a,b);
            for (int i=a; i<=b ; i++)
            {
                if (i%5==0)
                   {
                       
                       Console.WriteLine(i);
                       
                       p.Add(i);
                   }
               
            }
            int total = p.Count;
            Console.WriteLine("And they are {0} in total!", total);
            
        }
    }
}