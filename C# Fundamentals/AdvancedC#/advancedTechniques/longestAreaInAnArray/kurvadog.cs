using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace longestAreaInAnArray
{
    class kurvadog
    {
        static void Main()
    {
       
        string lastString = "", longestSeqString = "";
        uint longestSequence = 1, currentSequence = 0;
        Console.WriteLine("How many strings are you going to enter?");
        uint n = uint.Parse(Console.ReadLine());
        string[] strings = new string[n];
        for (uint i = 0; i < n; i++)
        {
            Console.WriteLine("Enter the {0} element of the array:", i+1);
            strings[i] = Console.ReadLine();
            if (lastString == strings[i])
            {
                currentSequence++;
                if (currentSequence > longestSequence)
                {
                    longestSequence = currentSequence;
                    longestSeqString = strings[i];
                   
                }
            }
            else
            {
                currentSequence = 1;
            }
            lastString = strings[i];
        }
        
 
        Console.WriteLine(longestSequence);
 
        for (int i = 1; i <= longestSequence; i++)
        {
            Console.WriteLine(longestSeqString);
        }
    }
    }
}
