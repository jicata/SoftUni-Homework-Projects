using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace endlessSequence
{
    class endlessSequence
    {
        static void Main()
        {
            string[] sequence = Console.ReadLine().Split();
            int[] myInts = sequence.Select(int.Parse).ToArray();
            int sum = myInts.Sum();

            Console.WriteLine(sum);
        }
    }
}
