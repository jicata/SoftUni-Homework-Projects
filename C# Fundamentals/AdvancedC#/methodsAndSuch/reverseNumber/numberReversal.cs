using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reverseNumber
{
    class numberReversal
    {
        static void Main()
        {
            double penis = reverseEngineering(3.14);
            Console.WriteLine(penis);

        }
       public static double reverseEngineering(double etoMe)
        {
           string stringy = etoMe.ToString();
           char[] charry = stringy.ToCharArray();
           Array.Reverse(charry);
           string soonToDouble = string.Empty;
           for (int i = 0; i < charry.Length; i++)
           {
               soonToDouble += charry[i];
           }
           double thereWeGo = double.Parse(soonToDouble);
           return thereWeGo;


        }
    }
}
