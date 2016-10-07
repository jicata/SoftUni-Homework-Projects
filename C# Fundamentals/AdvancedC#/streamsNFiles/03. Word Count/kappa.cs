using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _03.Word_Count
{
    class kappa
    {
        static void Main(string[] args)
        {
            string pathWords = @"../../words.txt";
            string pathTxt = @"../../text.txt";
            string pathResult = @"../../result.txt";
            List<string> themWords = new List<string>();
            List<string> theText = new List<string>();


            StreamReader words = new StreamReader(pathWords);
            StreamReader text = new StreamReader(pathTxt);
            StreamWriter result = new StreamWriter(pathResult);
            using(words)
            {
                string item = words.ReadLine();
                while(item!=null)
                {
                    themWords.Add(item);
                    item = words.ReadLine();
                }
            }
          
            using(text)
            {
                string line = text.ReadLine();
                string[] sentences;
                while (line != null)
                {
                    sentences = line.Split(new char[] {'.','?','!',' ','-',','},StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < sentences.Length; i++)
                    {
                       
                        theText.Add(sentences[i]);
                    }
                    line = text.ReadLine();
                    

                }
                
            }
            int counter =0;
            
            Dictionary<string, int> wordsOccurence = new Dictionary<string, int>();

            for (int i = 0; i < themWords.Count; i++)
            {
                for (int j = 0; j < theText.Count; j++)
                {
                    if (themWords[i] == theText[j].ToLower())
                    {
                        counter++;
                    }
                    
                }
                wordsOccurence.Add(themWords[i], counter);
              
                counter = 0;
            }
            
            
           
            using(result)
            {
                foreach (var item in wordsOccurence.OrderByDescending(i => i.Value))
                {
                    result.WriteLine("{0} - {1}", item.Key, item.Value);
                }
            }

            
        }
    }
}
