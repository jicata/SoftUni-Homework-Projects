using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pallindromes
{
    class sarahaPallindromes
    {
        static void Main()
        {
            string[] textInput = Console.ReadLine().Split(new char[] { ',', '.', '?', '!', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> pallindromes = new List<string>();

            string wordFromTxt = string.Empty;
            string reversed = string.Empty;
            for (int i = 0; i < textInput.Length; i++)
            {
                wordFromTxt = textInput[i];
                
                    if (wordFromTxt == ReverseThatHoe(wordFromTxt))
                    {
                        pallindromes.Add(wordFromTxt);
                    }
                    else
                    {
                        continue;
                    }
               
            }
            pallindromes.Sort();
            Console.WriteLine(string.Join(", ", pallindromes));
        }
        public static string ReverseThatHoe(string toBeReversed)
        {
            char[] storageSpace = toBeReversed.ToCharArray();
            Array.Reverse(storageSpace);
            return new string(storageSpace);
            
        }
    }
}
