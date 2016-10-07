using System;
using System.Linq;

namespace binaryToDecimal
{
    class Program
    {
        static void Main()
        {
            string bits = Console.ReadLine();
            var reversedBits = bits.Reverse().ToArray();
            var num = 0;
            for (var power = 0; power < reversedBits.Count(); power++)
            {
                var currentBit = reversedBits[power];
                if (currentBit == '1')
                {
                    var currentNum = (int)Math.Pow(2, power);
                    num += currentNum;
                }
               
            }
            Console.WriteLine(num);
        }
    }
}
