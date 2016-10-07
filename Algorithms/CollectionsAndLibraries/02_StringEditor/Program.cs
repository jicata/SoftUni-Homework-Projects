namespace _02_StringEditor
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Text;
    using System.Text.RegularExpressions;
    using Wintellect.PowerCollections;

    class Program
    {
        static void Main()
        {
            BigList<char> stringContainer = new BigList<char>();
            string command = " ";//Console.ReadLine();
            Regex commandNameMatcher = new Regex(@"([A-Z]*)\s?([\w\s#]+)?");
            Regex insertMatcher = new Regex(@"([A-Z]*) (\d+) (\w+)");
            Regex deletionMatcher = new Regex(@"([A-Z]*) (\d+) (\d+)");
            Regex replacementMatcher = new Regex(@"([A-Z]*) (\d+) (\d+) (\w+)");
            char[] stringToAdd = new char[0];
          
       
            while (command != "END")
            {

                string commandName = commandNameMatcher.Match(command).Groups[1].ToString();
            
                if (commandName!="PRINT" && commandName!="END")
                {
                    switch (commandName)
                    {
                        case "APPEND":
                            stringToAdd = commandNameMatcher.Match(command).Groups[2].ToString().ToCharArray();
                            Add(stringToAdd, stringContainer);
                            Console.WriteLine("OK");
                            break;
                        case "INSERT":
                            Match insertMatch = insertMatcher.Match(command);
                            int insertionIndex = int.Parse(insertMatch.Groups[2].ToString());
                            stringToAdd = insertMatch.Groups[3].ToString().ToCharArray();
                            Insert(stringToAdd, stringContainer, insertionIndex);
                            break;
                        case "DELETE":
                            Match deletionMatch = deletionMatcher.Match(command);
                            int startIndex = int.Parse(deletionMatch.Groups[2].ToString());
                            int count = int.Parse(deletionMatch.Groups[3].ToString());
                            Delete(stringContainer, startIndex, count);
                            break;
                        case "REPLACE":
                            Match replacementMatch = replacementMatcher.Match(command);
                            startIndex = int.Parse(replacementMatch.Groups[2].ToString());
                            count = int.Parse(replacementMatch.Groups[3].ToString());
                            stringToAdd = replacementMatch.Groups[4].ToString().ToCharArray();
                            Replace(startIndex, count, stringToAdd, stringContainer);
                            break;

                    }

                }
                else
                {
                    foreach (var item in stringContainer)
                    {
                        Console.Write(item);
                    }
                    Console.WriteLine();
                }

                command = Console.ReadLine();
            }

            // ->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> TEST ZONE <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<-
            //string command1 = "APPEND peshoWE";
            //string command2 = "INSERT 0 GOSHOBESHETUK";
            //string command3 = "DELETE 0 2";


            //// 100k appends
            //for (int i = 0; i < 100000; i++)
            //{

            //    stringToAdd = command1.Substring(6).ToCharArray();
            //    Add(stringToAdd, stringContainer);
            //}

            //// 100k inserts
            //for (int i = 0; i < 100000; i++)
            //{

            //    Match insertMatch = insertMatcher.Match(command2);
            //    int insertionIndex = int.Parse(insertMatch.Groups[2].ToString());
            //    stringToAdd = insertMatch.Groups[3].ToString().ToCharArray();
            //    Insert(stringToAdd, stringContainer, insertionIndex);
            //}

            //// 100k deletions
            //for (int i = 0; i < 100000; i++)
            //{
            //    Match deletionMatch = deletionMatcher.Match(command3);
            //    int startIndex = int.Parse(deletionMatch.Groups[2].ToString());
            //    int count = int.Parse(deletionMatch.Groups[3].ToString());
            //    Delete(stringContainer, startIndex, count);
            //}
        }

        private static void Replace(int startIndex, int count, char[] stringToAdd, BigList<char> stringContainer)
        {
            try
            {
                stringContainer.RemoveRange(startIndex, count);
                foreach (var character in stringToAdd)
                {
                    stringContainer.Insert(startIndex, character);
                    startIndex++;
                }
            }
            catch (Exception)
            {

                Console.WriteLine("ERROR");
            }
            Console.WriteLine("OK");
        }

        private static void Delete(BigList<char> stringContainer, int startIndex, int count)
        {
            try
            {
                stringContainer.RemoveRange(startIndex, count);
            }
            catch (Exception)
            {

                Console.WriteLine("ERROR");
            }
            Console.WriteLine("OK");
        }

        private static void Insert(char[] stringToAdd, BigList<char> stringContainer, int index)
        {
            try
            {
                foreach (var character in stringToAdd)
                {
                    stringContainer.Insert(index, character);
                    index++;
                }
            }
            catch (Exception)
            {

                Console.WriteLine("ERROR");
            }
            Console.WriteLine("OK");
        }

        private static void Add(char[] stringToAdd, BigList<char> stringContainer)
        {

            foreach (var character in stringToAdd)
            {
                stringContainer.Add(character);
            }
        }
    }
}
