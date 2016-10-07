namespace ddz
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
     
            Dictionary<char, Queue<int>> bunkaz = new Dictionary<char, Queue<int>>();
            Dictionary<char, int> sums = new Dictionary<char, int>();
            Queue<char> bunkerNames = new Queue<char>();
            int capacity = int.Parse(Console.ReadLine());
            string bunkerInfo = Console.ReadLine();
            char firstBunker = default(char);

            while (bunkerInfo != "Bunker Revision")
            {
                string[] shit = bunkerInfo.Split();


                for (int i = 0; i < shit.Length; i++)
                {
                    string currentitem = shit[i];
                    int isNum;
                    if (!int.TryParse(currentitem, out isNum))
                    {
                        bunkaz.Add(char.Parse(currentitem), new Queue<int>());
                        sums.Add(char.Parse(currentitem),0);
                        bunkerNames.Enqueue(char.Parse(currentitem));
                        continue;
                    }
                    if (firstBunker == default(char))
                    {
                        firstBunker = bunkerNames.Dequeue();
                    }

                    if (isNum + sums[firstBunker] > capacity && bunkaz.Keys.Count > 1)
                    {
                        if (bunkaz[firstBunker].Count > 0)
                        {
                            Console.WriteLine("{0} -> {1}", firstBunker, string.Join(", ", bunkaz[firstBunker]));
                        }
                        else
                        {
                            Console.WriteLine("{0} -> Empty", firstBunker);
                        }
                        bunkaz.Remove(firstBunker);
                        firstBunker = bunkerNames.Dequeue();
                        if (isNum <= capacity)
                        {
                            bunkaz[firstBunker].Enqueue(isNum);
                            sums[firstBunker] += isNum;
                        }
                    }
                    else if (isNum <= capacity && isNum + sums[firstBunker] > capacity && bunkaz.Keys.Count == 1)
                    {

                        while (sums[firstBunker] + isNum > capacity && bunkaz[firstBunker].Count > 0)
                        {
                            //bunkaz[firstBunker].Dequeue();
                            sums[firstBunker] -= bunkaz[firstBunker].Dequeue();
                        }
                        bunkaz[firstBunker].Enqueue(isNum);
                        sums[firstBunker] += isNum;

                    }
                    else
                    {
                        bunkaz[firstBunker].Enqueue(isNum);
                        sums[firstBunker] += isNum;
                    }
                }
                bunkerInfo = Console.ReadLine();
            }

        }
    }
}
