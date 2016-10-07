using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sortingNumbers
{
    class numberSort
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] arrayBruh = new int[n];

            for (int i = 0; i < arrayBruh.Length; i++)
            {
                arrayBruh[i] = int.Parse(Console.ReadLine());
            }
           Array.Sort(arrayBruh);
           for (int j = 0; j < arrayBruh.Length; j++)
           {
               Console.WriteLine(arrayBruh[j]);
           }
        }
    }
}
