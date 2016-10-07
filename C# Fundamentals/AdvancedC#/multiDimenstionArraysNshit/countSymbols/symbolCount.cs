using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace countSymbols
{
    class symbolCount
    {
        static void Main()
        {
            List<char> usedSymbols = new List<char>();

            string userInput = Console.ReadLine();
            char[] symbols = userInput.ToCharArray();
            int counter = 1;
           
            for (int i = 0; i < symbols.Length; i++)
            {
                switch(symbols[i])
                {
                    case '\t':
                    case '\r':
                    case '\n':
                    {
                        symbols[i]= ' ';
                        break;
                    }
                }
            }
            Array.Sort<char>(symbols);
            for (int i = 0; i < symbols.Length; i++)
            {
                if (usedSymbols.Contains(symbols[i]))
                {
                    continue;
                }

                for (int j = i+1; j < symbols.Length; j++)
                {
                  
                    if (symbols[i] == symbols[j])
                    {
                        
                        counter++;
                    }
                    
                    
                    
                }
                
              
                    Console.WriteLine("{0}: {1} time(s)", symbols[i], counter);
                    
                
                
                counter = 1;
                usedSymbols.Add(symbols[i]);
                    
                
                
            }
        }
    }
}
