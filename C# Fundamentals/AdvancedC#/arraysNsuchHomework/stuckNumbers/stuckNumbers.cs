using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stuckNumbers
{
    class stuckNumbers
    {
        static void Main()
        {
            int countOfCucumbers = int.Parse(Console.ReadLine());
            string[] numberinos = new string[countOfCucumbers];
            int counter = 0;

            numberinos = Console.ReadLine().Split();

            for (int num1 = 0; num1 < numberinos.Length; num1++)
            {
                for (int num2 = 0; num2 < numberinos.Length; num2++)
                {
                    for (int num3 = 0; num3 < numberinos.Length; num3++)
                    {
                        for (int num4 = 0; num4 < numberinos.Length; num4++)
                        {
                            string a = numberinos[num1];
                            string b = numberinos[num2];
                            string c = numberinos[num3];
                            string d = numberinos[num4];
                            if (a != b && a != c && a !=d && b != c && b!=d && c != d)
                            {
                                string firstNumber = a + b;
                                string secondNumber = c + d;
                                if (firstNumber == secondNumber)
                                {
                                    Console.WriteLine("{0}|{1}=={2}|{3}",a,b,c,d);
                                    counter++;

                                }
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
