using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biggerNumbes
{
    class numbeeesss
    {
        static void Main()
        {
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());
            
            Console.WriteLine(BiggurNumbe(numberOne, numberTwo));

        }
        public static int BiggurNumbe(int aNumber, int anotherNumber)
        {
            int biggur = int.MinValue;
            if (aNumber > anotherNumber)
            {
                biggur = aNumber;
            }
            else
            {
                biggur = anotherNumber;
            }
            return biggur;
        }
    }
}
