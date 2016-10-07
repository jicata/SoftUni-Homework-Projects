using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filterCurseWOrds
{
    class filter
    {
        static void Main()
        {
            string theWords = Console.ReadLine();
            string[] forbiddenWords = theWords.Split(new char[]{',', ' '}, StringSplitOptions.RemoveEmptyEntries).Select(x => x).ToArray();
            string userText = Console.ReadLine();
            StringBuilder censored = new StringBuilder(userText);
            string bannedWord = string.Empty;
            int replaceIndex = 0;
            int startIndex = 0;

            for (int i = 0; i < forbiddenWords.Length; i++)
            {
                Console.WriteLine(forbiddenWords[i]);
            }
            for (int i = 0; i < forbiddenWords.Length; i++)
            {
                bannedWord = forbiddenWords[i];
                replaceIndex = 0;
                while (replaceIndex !=-1)
                {
                    replaceIndex = userText.IndexOf(bannedWord, startIndex);
                    if (replaceIndex == -1)
                    {
                        startIndex = 0;
                        continue;
                        
                    }
                    else
                    {
                        for (int k = 0; k < bannedWord.Length; k++)
                        {
                            censored[k + replaceIndex] = '*';
                        }
                        startIndex = replaceIndex + 1;
                    }
                    
                }
            }
            Console.WriteLine(censored);
        }
       

    }
}
