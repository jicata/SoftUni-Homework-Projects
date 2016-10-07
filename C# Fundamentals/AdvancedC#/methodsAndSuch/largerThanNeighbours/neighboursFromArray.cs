using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace largerThanNeighbours
{
    class neighboursFromArray
    {
        static void Main()
        {
            int[] suchArray = { 1, 3, 4, 5, 1, 0, 5 };
            for (int i = 0; i < suchArray.Length; i++)
            {
               
                Console.WriteLine(IsLarger(suchArray, i));
            }
            
        }
        


           public static bool IsLarger(int[] loArra, int i)
        {



            bool yeah = false;

            if (i - 1 < 0 )
               {
                 if (loArra[i] > loArra[i + 1])
                   {
                       yeah = true;
                       return yeah;
                   } 
               }

            else if (i +1 > loArra.Length-1)
            {
                if (loArra[i] > loArra[i-1])
                   {
                    yeah = true;
                    return yeah;
                   }
            }

            else  if ((i +1 < loArra.Length && i - 1 > 0) && loArra[i]> loArra[i-1] && loArra[i] > loArra[i+1])
                   {
                        yeah = true;
                   }
                    
                
            else
                   {
                    yeah = false;
                    
                   }
                    return yeah;
            
           }
    }

}
