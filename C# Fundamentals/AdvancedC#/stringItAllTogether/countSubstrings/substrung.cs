using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace countSubstrings
{
    class substrung
    {
        static void Main()
        {
            string userString = Console.ReadLine();
            string searchFor = Console.ReadLine().ToLower();
            string lowerUser = userString.ToLower();
            int counter = 0;
            int findIt = 0;
            int lastIndex = 0;

            while(findIt != -1)
            {
               
                findIt = lowerUser.IndexOf(searchFor, lastIndex);
               if (findIt!=-1)
               {
                   counter++;
                   lastIndex = findIt + searchFor.Length - 1;
               }
               else
               {
                   break;
               }
                    
                
                
              
                
            }
            
            Console.WriteLine(counter);

        }
    }
}
