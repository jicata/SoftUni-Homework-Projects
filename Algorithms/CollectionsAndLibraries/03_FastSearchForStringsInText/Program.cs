namespace _03_FastSearchForStringsInText
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    class Program
    {
        static void Main()
        {
            BigList<char> stringStorage = new BigList<char>();
            Dictionary<string,int> itemsByOccurence = new Dictionary<string,int>();
            int numberOfItemsToSearchFor = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfItemsToSearchFor; i++)
            {
                itemsByOccurence[Console.ReadLine().ToLower()] = 0;
            }
            int linesOfText = int.Parse(Console.ReadLine());

            for (int i = 0; i < linesOfText; i++)
            {
                string input = Console.ReadLine().ToLower();
                char[] inputToInsert = input.ToCharArray();
                foreach (var item in inputToInsert)
                {
                    stringStorage.Add(item);
                }

            }
            var keys = itemsByOccurence.Keys;
            for (int i = 0; i < stringStorage.Count; i++)
            {
                char currentChar = stringStorage[i];
       
                List<string> partialMatches = new List<string>();
                foreach (var key in keys)
                {
                    if (key[0] == currentChar)
                    {
                        partialMatches.Add(key);
                    }
                }

                if (partialMatches.Any())
                {
                    foreach (var partialMatch in partialMatches)
                    {
                        bool isNotEndOfText= partialMatch.Length + i < stringStorage.Count;
                        if (isNotEndOfText)
                        {
                            StringBuilder sb =new StringBuilder();
                            var rangeToMatch = stringStorage.GetRange(i, partialMatch.Length);
                            foreach (var possibleMatch in rangeToMatch)
                            {
                                sb.Append(possibleMatch);
                            }
                            if (sb.ToString() == partialMatch)
                            {
                                itemsByOccurence[partialMatch]++;
                            }
                        }
                    }
                }
            }
            foreach (var item in itemsByOccurence)
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }
               
           

        }
    }
}
