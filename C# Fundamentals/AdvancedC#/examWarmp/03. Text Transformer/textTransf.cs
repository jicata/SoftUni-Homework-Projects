using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _03.Text_Transformer
{
    class textTransf
    {
        static void Main()
        {
            string userInputString = Console.ReadLine();
            List<string> userInputList = new List<string>();
            StringBuilder consolidatedStrings = new StringBuilder();
            while(userInputString != "burp")
            {
                consolidatedStrings.Append(userInputString);
                userInputString = Console.ReadLine();
            }
            

            
            string consol = consolidatedStrings.ToString();
            
            StringBuilder textReady = new StringBuilder(Regex.Replace(consol, @"\s+", " "));
            string ayeaye = textReady.ToString();

            string pattern = @"([$&'%]+)([^$&%']+)\1";
            var rgx = new Regex(pattern);

            MatchCollection gotEm = rgx.Matches(ayeaye);
            List<StringBuilder> messages = new List<StringBuilder>();
            var specialSymbolWeights = new Dictionary<char, int>
        {
            {'$', 1},
            {'%', 2},
            {'&', 3},
            {'\'', 4}
        };
            StringBuilder result = new StringBuilder();
            foreach (Match match in gotEm)
            {
                char specChar = match.Groups[1].Value[0];
                string crypted = match.Groups[2].Value;
                int stringLength = crypted.Length;
                for (int i = 0; i < stringLength; i++)
                {
                    char currentSymbol = crypted[i];
                    char resultingChar;
                    if(i==0 || i% 2 == 0)
                    {
                        resultingChar = (char)(currentSymbol + specialSymbolWeights[specChar]);
                    }
                    else
                    {
                        resultingChar = (char)(currentSymbol - specialSymbolWeights[specChar]);
                    }
                    result.Append(resultingChar);
                }
                //messages.Add(StringDecrypt(crypted, specChar));
                result.Append(" ");
            }
            Console.WriteLine(result);
            
           
            
            
            Console.WriteLine(string.Join(" ", messages));
        }
        static StringBuilder StringDecrypt(string toDecrypt, string weightChar)
        {
            int weight = 0;
            switch(weightChar)
            {
                case "$": weight = 1;
                    break;
                case "%": weight = 2;
                    break;
                case "&": weight = 3;
                    break;
                case "'": weight = 4;
                    break;
            }
            List<char> decryptedChars = new List<char>();
            char decr = ' ';
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < toDecrypt.Length; i++)
            {
                if(i == 0 || i % 2 == 0 )
                {
                    int charAscii = toDecrypt[i] + weight;
                    decr = (char)charAscii;
                    sb.Append(decr);
                }
                else
                {
                    int charAscii = toDecrypt[i] - weight;
                    decr = (char)charAscii;
                    sb.Append(decr);
                }
            }
            
            return sb;
        }
    }
}
