using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Array_Manip
{
    class letsgo
    {
        static void Main()
        {
            int[] userInput = Console.ReadLine().Split().Select(x=>int.Parse(x)).ToArray();
            List<int> collection = userInput.ToList();

            string userCommands = Console.ReadLine();
            while(userCommands!="end")
            {
                string[] specificCommands = userCommands.Split();
                string keyword = specificCommands[0];
                if (keyword == "exchange")
                {
                    int index = int.Parse(specificCommands[1]);
                    if (index >=0 && index < collection.Count)
                    {
                        SplitAndReturn(collection, index);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                        userCommands = Console.ReadLine();
                        continue;
                    }
                }
                if (keyword == "max" || keyword == "min")
                {
                    string oddOrEven = specificCommands[1];
                    if (keyword == "max")
                    {
                        if (oddOrEven == "odd" && IsThereOdd(collection))
                        {
                            Console.WriteLine(MaxOdd(collection));
                        }
                        else if (oddOrEven == "even" && IsThereEven(collection))
                        {
                            Console.WriteLine(MaxEven(collection));
                        }
                        else
                        {
                            Console.WriteLine("No matches");
                        }
                    }
                    if (keyword == "min")
                    {
                        if (oddOrEven == "odd" && IsThereOdd(collection))
                        {
                            Console.WriteLine(MinOdd(collection));
                        }
                        else if (oddOrEven == "even" && IsThereEven(collection))
                        {
                            Console.WriteLine(MinEven(collection));
                        }
                        else
                        {
                            Console.WriteLine("No matches");
                        }
                    }
                }
                if (keyword == "first" || keyword == "last")
                {
                    int count = int.Parse(specificCommands[1]);
                    string oddOrEven = specificCommands[2];
                    if (count > collection.Count)
                    {
                        Console.WriteLine("Invalid count");
                    }
                    if (keyword == "first" && count <= collection.Count)
                    {
                        if (oddOrEven == "odd" && IsThereOdd(collection))
                        {
                            FirstOdd(collection, count);
                        }
                        else if(oddOrEven == "even" && IsThereEven(collection))
                        {
                            FirstEven(collection, count);
                        }
                        else
                        {
                            Console.WriteLine("[]");
                        }
                    }
                    if (keyword == "last" && count <= collection.Count)
                    {
                        if (oddOrEven == "odd" && IsThereOdd(collection))
                        {
                            LastOdd(collection, count);
                        }
                        else if (oddOrEven == "even" && IsThereEven(collection))
                        {
                            LastEven(collection, count);
                        }
                        else
                        {
                            Console.WriteLine("[]");
                        }
                    }
                   
                    
                }

                userCommands = Console.ReadLine();
            }
            Console.WriteLine("[{0}]",string.Join(", ", collection));
        }
        public static void SplitAndReturn(List<int> collec, int index)
        {
            List<int> tempList1 = new List<int>();
            List<int> tempList2 = new List<int>();
            index++;
            
            for (int i = 0; i < index; i++)
            {
                tempList1.Add(collec[i]);
            }
            for (int i = index; i < collec.Count; i++)
            {
                tempList2.Add(collec[i]);
            }
            List<int> gluedTogether = new List<int>(tempList2.Concat(tempList1));

            for (int i = 0; i < collec.Count; i++)
            {
                collec[i] = gluedTogether[i];
            }
            
        }
        public static int MaxEven(List<int> collect)
        {
            int maxEven = int.MinValue;
            for (int i = 0; i < collect.Count; i++)
            {
                if (collect[i] % 2 == 0 && collect[i] > maxEven)
                {
                    maxEven = collect[i];
                }
            }
            int indexOf = collect.LastIndexOf(maxEven);
            return indexOf;
        }
        public static int MaxOdd(List<int> collect)
        {
            int maxOdd = int.MinValue;
            for (int i = 0; i < collect.Count; i++)
            {
                if (collect[i] % 2 > 0 && collect[i] > maxOdd)
                {
                    maxOdd = collect[i];
                }
            }
            int indexOf = collect.LastIndexOf(maxOdd);
            return indexOf;
        }
        public static int MinEven(List<int> collect)
        {
            int minEven = int.MaxValue;
            for (int i = 0; i < collect.Count; i++)
            {
                if (collect[i] % 2 == 0 && collect[i] < minEven)
                {
                    minEven = collect[i];
                }
            }
            int indexOf = collect.LastIndexOf(minEven);
            return indexOf;
        }
        public static int MinOdd(List<int> collect)
        {
            int minOdd = int.MaxValue;
            for (int i = 0; i < collect.Count; i++)
            {
                if (collect[i] % 2 > 0 && collect[i] < minOdd)
                {
                    minOdd = collect[i];
                }
            }
            int indexOf = collect.LastIndexOf(minOdd);
            return indexOf;
        }
        public static void FirstOdd(List<int> collect, int count)
        {
            int finalCount = count;
            List<int> allOdds = new List<int>();
            List<int> countOdds = new List<int>();
            for (int i = 0; i < collect.Count; i++)
            {
                if (collect[i] % 2 > 0 )
                {
                    allOdds.Add(collect[i]);
                }
            }
            if (allOdds.Count < finalCount)
            {
                Console.WriteLine("[{0}]",string.Join(", ", allOdds));
            }
            else
            {
                for (int i = 0; i < finalCount; i++)
                {
                    countOdds.Add(allOdds[i]);
                }
                Console.WriteLine("[{0}]", string.Join(", ", countOdds));
            }
        }
        public static void FirstEven(List<int> collect, int count)
        {
            int finalCount = count;
            List<int> allOdds = new List<int>();
            List<int> countOdds = new List<int>();
            for (int i = 0; i < collect.Count; i++)
            {
                if (collect[i] % 2 == 0)
                {
                    allOdds.Add(collect[i]);
                }
            }
            if (allOdds.Count < finalCount)
            {
                Console.WriteLine("[{0}]", string.Join(", ", allOdds));
            }
            else
            {
                for (int i = 0; i < finalCount; i++)
                {
                    countOdds.Add(allOdds[i]);
                }
                Console.WriteLine("[{0}]", string.Join(", ", countOdds));
            }
        }
        public static void LastOdd(List<int> collect, int count)
        {
            List<int> allTheOdds = new List<int>();
            List<int> justTheRightOdds = new List<int>();
            for (int i = collect.Count-1; i >= 0; i--)
            {
                if (collect[i] % 2 > 0)
                {
                    allTheOdds.Add(collect[i]);
                }
                
            }
            allTheOdds.Reverse();
            if(allTheOdds.Count < count)
            {
                Console.WriteLine("[{0}]", string.Join(", ", allTheOdds));
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    justTheRightOdds.Add(allTheOdds[i]);
                }
                Console.WriteLine("[{0}]", string.Join(", ", justTheRightOdds));
            }
        }
        public static void LastEven(List<int> collect, int count)
        {
            List<int> allTheOdds = new List<int>();
            List<int> justTheRightOdds = new List<int>();
            for (int i = collect.Count - 1; i >= 0; i--)
            {
                if (collect[i] % 2 == 0)
                {
                    allTheOdds.Add(collect[i]);
                }

            }
            allTheOdds.Reverse();
            if (allTheOdds.Count < count)
            {
                Console.WriteLine("[{0}]", string.Join(", ", allTheOdds));
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    justTheRightOdds.Add(allTheOdds[i]);
                }
                Console.WriteLine("[{0}]", string.Join(", ", justTheRightOdds));
            }
        }
        public static bool IsThereEven(List<int> collect)
        {
            bool even = false;
            for (int i = 0; i < collect.Count; i++)
            {
                if (collect[i] % 2 == 0)
                {
                    even = true;
                    return even;
                }
            }
            return even;
        }
        public static bool IsThereOdd(List<int> collect)
        {
            bool odd = false;
            for (int i = 0; i < collect.Count; i++)
            {
                if (collect[i] % 2 > 0 || collect[i] == 1)
                {
                    odd = true;
                    return odd;
                }
            }
            return odd;
        }
    }
}
