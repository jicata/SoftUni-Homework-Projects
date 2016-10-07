namespace ArrayManipulator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int[] myArray = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] commandArgs = command.Split();
                if (commandArgs[0] == "exchange")
                {
                    int index = int.Parse(commandArgs[1]);
                    if (index < 0 || index >= myArray.Length)
                    {
                        Console.WriteLine("Invalid index");

                    }
                    else
                    {
                        myArray = Exchange(index, myArray);
                        
                    }

                }
                if (commandArgs[0] == "max")
                {
                    if (commandArgs[1] == "odd")
                    {
                        MaxOdd(myArray);
                    }
                    else
                    {
                        MaxEven(myArray);
                    }
                }
                if (commandArgs[0] == "min")
                {
                    if (commandArgs[1] == "odd")
                    {
                        MinOdd(myArray);
                    }
                    else
                    {
                        MinEven(myArray);
                    }
                }
                if (commandArgs[0] == "first")
                {
                    if (commandArgs[2] == "odd")
                    {
                        PrintFirstOdd(int.Parse(commandArgs[1]), myArray);
                    }
                    else
                    {
                        PrintFirstEven(int.Parse(commandArgs[1]), myArray);
                    }
                }
                if (commandArgs[0] == "last")
                {
                    if (commandArgs[2] == "odd")
                    {
                        PrintLastOdd(int.Parse(commandArgs[1]), myArray);
                    }
                    else
                    {
                        PrintLastEven(int.Parse(commandArgs[1]), myArray);
                    }
                }

                command = Console.ReadLine();
            }
            Console.WriteLine(string.Format("[{0}]", string.Join(", ", myArray)));
        }

        private static void PrintLastEven(int count, int[] array)
        {
            if (count > array.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            

            List<int> firstOdds = new List<int>();
            for (int i = array.Length-1; i >= 0; i--)
            {
                if (array[i] % 2 == 0)
                {
                    firstOdds.Add(array[i]);
                }
                if (firstOdds.Count == count)
                {
                    break;
                }
            }
            List<int> thisTimeForSure = new List<int>();
            if (firstOdds.Any())
            {
                firstOdds.Reverse();
                for (int i = 0; i < Math.Min(firstOdds.Count,count); i++)
                {
                    thisTimeForSure.Add(firstOdds[i]);
                }
            }
            
            Console.WriteLine(string.Format("[{0}]", string.Join(", ", thisTimeForSure)));
        }

        private static void PrintLastOdd(int count, int[] array)
        {
            if (count > array.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            

            List<int> firstOdds = new List<int>();
            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] % 2 != 0)
                {
                    firstOdds.Add(array[i]);
                }
                if (firstOdds.Count == count)
                {
                    break;
                }
            }
            List<int> thisTimeForSure = new List<int>();
            if (firstOdds.Any())
            {
                firstOdds.Reverse();
                for (int i = 0; i < Math.Min(firstOdds.Count,count); i++)
                {
                    thisTimeForSure.Add(firstOdds[i]);
                }
            }

            Console.WriteLine(string.Format("[{0}]", string.Join(", ", thisTimeForSure)));
        }

        private static void PrintFirstEven(int count, int[] array)
        {
            if (count > array.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            List<int> firstOdds = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    firstOdds.Add(array[i]);
                }
            }
            List<int> thisTimeForSure = new List<int>();
            if (firstOdds.Any())
            {
                for (int i = 0; i < Math.Min(firstOdds.Count,count); i++)
                {
                    thisTimeForSure.Add(firstOdds[i]);
                }
            }
            Console.WriteLine(string.Format("[{0}]", string.Join(", ", thisTimeForSure)));
        }

        private static void PrintFirstOdd(int count, int[] array)
        {
            if (count > array.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            List<int> firstOdds = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    firstOdds.Add(array[i]);
                }
            }
            List<int> thisTimeForSure = new List<int>();
            if (firstOdds.Any())
            {
                for (int i = 0; i < Math.Min(count, firstOdds.Count); i++)
                {
                    thisTimeForSure.Add(firstOdds[i]);
                }
            }
            Console.WriteLine(string.Format("[{0}]", string.Join(", ", thisTimeForSure)));
        }

        private static void MinEven(int[] array)
        {
            int min = int.MaxValue;
            int index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0 && array[i] <= min)
                {
                    min = array[i];
                    index = i;
                }
            }
            if (min == int.MaxValue)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(index);
            }
        }

        private static void MaxEven(int[] array)
        {
            int max = int.MinValue;
            int index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0 && array[i] >= max)
                {
                    max = array[i];
                    index = i;
                }
            }
            if (max == int.MinValue)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(index);
            }
        }

        private static void MinOdd(int[] array)
        {
            int min = int.MaxValue;
            int index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0 && array[i] <= min)
                {
                    min = array[i];
                    index = i;
                }
            }
            if (min == int.MaxValue)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(index);
            }
        }

        private static void MaxOdd(int[] array)
        {
            int max = int.MinValue;
            int index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0 && array[i] >= max)
                {
                    max = array[i];
                    index = i;
                }
            }
            if (max == int.MinValue)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(index);
            }
        }

        private static int[] Exchange(int index, int[] array)
        {

            List<int> firstPart = new List<int>();
            List<int> secondPart = new List<int>();

            for (int i = index+1; i < array.Length; i++)
            {
                firstPart.Add(array[i]);
            }
            for (int i = 0; i <= index; i++)
            {
                secondPart.Add(array[i]);
            }
            List<int> merged = new List<int>(firstPart);
            foreach (var item in secondPart)
            {
                merged.Add(item);
            }
            return merged.ToArray();
        }
    }
}
