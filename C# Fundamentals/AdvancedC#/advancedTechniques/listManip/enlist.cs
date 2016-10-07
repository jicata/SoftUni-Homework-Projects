using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace listManip
{
    class enlist
    {
        static void Main()
        {
            Console.WriteLine("First set of names: ");
            string firstNames = Console.ReadLine();
            string[] arrayNames = firstNames.Split();

            Console.WriteLine("Second set of names: ");
            string secondNames = Console.ReadLine();
            string[] arrayRemoveNames = secondNames.Split();


            List<string> listche = new List<string>();
            List<string> mahaiListcheto = new List<string>();


            foreach (var parche in arrayNames)
            {
                listche.Add(parche);
            }

            foreach (var parchok in arrayRemoveNames)
            {
                mahaiListcheto.Add(parchok);
            }
            for (int j = 0; j < mahaiListcheto.Count; j++)
            {
                listche.RemoveAll(chep => chep == mahaiListcheto[j]);
            }

         
            for (int j = 0; j < listche.Count; j++)
            {
                Console.Write("{0} ",listche[j]);
            }
            Console.WriteLine();
        }
    }
}
