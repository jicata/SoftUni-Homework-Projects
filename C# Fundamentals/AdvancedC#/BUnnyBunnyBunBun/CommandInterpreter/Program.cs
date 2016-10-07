namespace CommandInterpreter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
         
            string[] workableArray = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] commandArgs = command.Split();
                string commandName = commandArgs[0];
                if (commandName == "reverse" || commandName == "sort")
                {
                    int startingIndex = int.Parse(commandArgs[2]);
                    int count = int.Parse(commandArgs[4]);
                    bool validCount = startingIndex + count <= workableArray.Length;
                    if (startingIndex < 0 || startingIndex > workableArray.Length || !validCount || count < 0 || count > workableArray.Length)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        command = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        if (commandName == "reverse")
                        {
                            workableArray = ReverseTheArray(workableArray, startingIndex, count);
                        }
                        else
                        {
                            workableArray = SortTheArray(workableArray, startingIndex, count);
                        }
                    }

                }
                else
                {
                    int count = int.Parse(commandArgs[1]);
                    if (count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        command = Console.ReadLine();
                        continue;
                    }
                    if (commandName == "rollLeft")
                    {
                        workableArray = RollToTheLeft(workableArray, count);
                    }
                    else
                    {
                        workableArray = RollToTheRight(workableArray, count);
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Format("[{0}]", string.Join(", ", workableArray)));
        }

        private static string[] RollToTheRight(string[] workableArray, int count)
        {
            int numberOfRolls = count % workableArray.Length;
            List<string> leftSide = new List<string>();
            List<string> rightSide = new List<string>();
            for (int i = workableArray.Length -numberOfRolls; i < workableArray.Length; i++)
            {
                rightSide.Add(workableArray[i]);
            }
            for (int i = 0; i < workableArray.Length - numberOfRolls; i++)
            {
                leftSide.Add(workableArray[i]);
            }
            var result = rightSide.Concat(leftSide);
            return result.ToArray();
        }

        private static string[] RollToTheLeft(string[] workableArray, int count)
        {
            int numberOfRolls = count % workableArray.Length;
            List<string> leftSide = new List<string>();
            List<string> rightSide = new List<string>();
            for (int i = 0; i < numberOfRolls; i++)
            {
                leftSide.Add(workableArray[i]);
            }
            for (int i = numberOfRolls; i < workableArray.Length; i++)
            {
                rightSide.Add(workableArray[i]);
            }
            var result = rightSide.Concat(leftSide);
            return result.ToArray();
        }

        private static string[] SortTheArray(string[] workableArray, int startingIndex, int count)
        {
            Array.Sort(workableArray, startingIndex, count, StringComparer.InvariantCulture);
            return workableArray;
        }

        private static string[] ReverseTheArray(string[] array, int startingIndex, int count)
        {
            List<string> letsDoIt = new List<string>(array);
            letsDoIt.Reverse(startingIndex, count);
            return letsDoIt.ToArray();
        }
    }
}
