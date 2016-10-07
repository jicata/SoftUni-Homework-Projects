using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace longestWord
{
    class longestWord
    {
       
        static void Main()
        {
            string input = Console.ReadLine();
            string[] arrayBruh = input.Split();
            List<string> listche = new List<string>();

            foreach (var word in arrayBruh)
            {
                listche.Add(word);

            }
             int max = int.MinValue;
            

            foreach (var word in arrayBruh)
            {
                int wordLength = word.ToString().Length;
               
                if (wordLength > max) max = wordLength;
            }
           
            foreach (string s in SortByLength(listche))
            {
               
                
                if (s.Length == max)
                {
                    Console.WriteLine(s);
                }
            }



           
           
        }
        static IEnumerable<string> SortByLength(IEnumerable<string> e)
        {
            // Use LINQ to sort the array received and return a copy.
            var sorted = from s in e
                         orderby s.Length ascending
                         select s;
            return sorted;
        }
       
    }
}
