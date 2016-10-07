using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pythagoreanNumbers
{
    class traplets
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            double[] lesNumers = new double[n];
            int counter = 0;
            for (int i = 0; i < n; i++)
            {
                lesNumers[i] = double.Parse(Console.ReadLine());
            }
            for (int num1 = 0; num1 < n; num1++)
            {
                for (int num2 = 0; num2 < n; num2++)
                {
                    for (int num3 = 0; num3 < n; num3++)
                    {
                        double a = lesNumers[num1];
                        double b = lesNumers[num2];
                        double c = lesNumers[num3];
                        if (b >= a)
                        {
                            if (Math.Pow(a,2) + Math.Pow(b,2) == Math.Pow(c,2))
                            {
                                Console.WriteLine("{0}*{0} + {1}*{1} = {2}*{2}", a, b ,c);
                                counter++;
                            }
                        }
                    }
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("No");
            }
        }
    }
}
