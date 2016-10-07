using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jointList
{
    class jointList
    {
        static void Main()
        {
          
            string firstInput = Console.ReadLine();
           
            string secondInput = Console.ReadLine();
            


            string[] firstArray = firstInput.Split();
           // int[] firstIntArray = Array.ConvertAll(firstArray, int.Parse);
            string[] secondArray = secondInput.Split();
            //int[] secondIntArray = Array.ConvertAll(secondArray, int.Parse);


            List<int> firstNumbers = new List<int>();
            List<int> secondNumbers = new List<int>();

            foreach (var chep in firstArray)
            {
                int ok = int.Parse(chep);
                firstNumbers.Add(ok);
            }
            foreach (var bah in secondArray)
            {
                int ok1 = int.Parse(bah);
                secondNumbers.Add(ok1);
            }
            
            //for (int i = 0; i < firstNumbers.Count; i++)
            //{
            //    Console.WriteLine(firstNumbers[i]);
            //}
          
            IEnumerable<int> union = firstNumbers.Union(secondNumbers);
            List<int> chepche= union.ToList();
            chepche.Sort();
            for (int i = 0; i < chepche.Count(); i++)
            {
                Console.Write("{0} ", chepche[i]);
            }
            Console.WriteLine();
           
        }
    }
}
