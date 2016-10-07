using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace letsGO
{
    class stringreversal
    {
        static void Main()
        {

            string toBeReversed = Console.ReadLine();
            char[] reverseInProcess = toBeReversed.ToCharArray();
            Array.Reverse(reverseInProcess);
            string reversed = string.Empty;
            for (int i = 0; i < reverseInProcess.Length; i++)
            {
                reversed += reverseInProcess[i];
            }
            Console.WriteLine(reversed);

            
        }
    }
}
