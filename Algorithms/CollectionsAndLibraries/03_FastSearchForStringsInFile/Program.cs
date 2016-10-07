namespace _03_FastSearchForStringsInFile
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    class Program
    {
        static void Main()
        {
            //In order to test the algorithm for larger files we need to create a large file first.
            //An easy way to do this is the following:
            // 1. Open your command prompt (typing "cmd" in your default search bar for Windows)
            // 2. Notice what the current directory is
            // 3. Type in "FSUTIL FILE CREATENEW testfile.txt 104857600" (no quotation marks)
            // 4. Find the file in the current directory
            // 5. Copy and paste the path here.
            // 6. Voila! You have a 100 mb text file to work it. It's empty tho.

            BigList<char> stringStorage = new BigList<char>();
            Dictionary<string, int> itemsByOccurence = new Dictionary<string, int>();
            string path = @"C:\Users\Maika\Documents\visual studio 2015\Projects\CollectionsAndLibraries\03_FastSearchForStringsInFile\LoremIpsum.txt";
            //string path = @"D:\testfile.txt";

            //read the text file
            Stopwatch speedTest = new Stopwatch();
            speedTest.Start();
            string text = File.ReadAllText(path).ToLower();
            Console.WriteLine("Reading DONE! Operation time: {0}", speedTest.Elapsed);

            //choose a few random strings to search for, number of occurences should be known beforehand
            itemsByOccurence.Add("fring", 0); // 51
            itemsByOccurence.Add("in", 0); // 587
            itemsByOccurence.Add("cur",0); // 85
            itemsByOccurence.Add("mauris", 0); // 76

            //convert the text into a series of characters and store them
            foreach (var character in text)
            {
                stringStorage.Add(character);
            }
            Console.WriteLine("Convertion DONE! Operation time: {0}", speedTest.Elapsed);

            //perform the necessary matching algorithm
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
                        bool isNotEndOfText = partialMatch.Length + i < stringStorage.Count;
                        if (isNotEndOfText)
                        {
                            StringBuilder sb = new StringBuilder();
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
            //print result if any
            foreach (var item in itemsByOccurence)
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }
            Console.WriteLine();
            Console.WriteLine("Program COMPLETE! Operation time: {0}", speedTest.Elapsed);
        }
    }
}
