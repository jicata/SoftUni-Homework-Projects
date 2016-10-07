using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace arraySlider
{
    class Program
    {
        static void Main()
        {
            BigInteger[] arr = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries).Select(x=>BigInteger.Parse(x)).ToArray();
            string line = Console.ReadLine();
            int currentIndex = 0;
            while (line!= "stop")
            {
                var lineArgs = line.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                int offset = int.Parse(lineArgs[0])% arr.Length;
                string operation = lineArgs[1];
                BigInteger opop = BigInteger.Parse(lineArgs[2]);

                line = Console.ReadLine();
                
                if (offset < 0 )
                {
                    currentIndex = (currentIndex + offset + arr.Length) % arr.Length;
                }
                else
                {
                    currentIndex = (currentIndex + offset) % arr.Length;
                }
                ProccessCommand(arr, currentIndex, operation, opop);
                
                
            }
            Console.WriteLine("[{0}]",string.Join(", ",arr));
        }
        public static void ProccessCommand(BigInteger[] arra, int currentIndex, string operation, BigInteger opop)
        {
            switch(operation)
            {
                case "&":
                    arra[currentIndex] &= (long)opop;
                    break;
                case"|":
                    arra[currentIndex] |= (long)opop;
                    break;
                case"^":
                    arra[currentIndex] ^= (long)opop;
                    break;
                case"-":
                    arra[currentIndex] -= (long)opop;
                    if (arra[currentIndex] < 0)
                    {
                        arra[currentIndex] = 0;
                    }
                    break;
                case"/":
                    arra[currentIndex] /= (long)opop;
                    break;
                case"*":
                    arra[currentIndex] *= (long)opop;
                    break;
                case"+":
                    arra[currentIndex] += (long)opop;
                    break;
                
            }
        }
    }
}
