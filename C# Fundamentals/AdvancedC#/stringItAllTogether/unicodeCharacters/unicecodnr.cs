using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unicodeCharacters
{
    class unicecodnr
    {
        static void Main(string[] args)
        {
            string userInput = Console.ReadLine();
            for (int i = 0; i < userInput.Length; i++)
            {
                Console.Write("{0} ",ConvertToUnicodeHex(userInput[i]));
            }
            Console.WriteLine();
        }
        public static string ConvertToUnicodeHex(char c)
        {
            string unicode = "\\u" + ((int)c).ToString("x4");
            return unicode;
        }
    }
}
