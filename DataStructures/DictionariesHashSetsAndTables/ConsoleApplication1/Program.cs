namespace ConsoleApplication1
{
    using System;
    using System.Linq;
    using DictionaryHashTable;

    class Program
    {
        static void Main()
        {
            HashTable<char, int> symbolCounter = new HashTable<char, int>();
            char[] input = Console.ReadLine().ToCharArray();

            for (int i = 0; i < input.Length; i++)
            {
                if (!symbolCounter.ContainsKey(input[i]))
                {
                    symbolCounter.Add(input[i], 1);
                }
                else
                {
                    symbolCounter[input[i]] ++;
                }
            }

            var keys = symbolCounter.Keys.OrderBy(x => x);

            foreach (var key in keys)
            {
                Console.WriteLine("{0}: {1} time/s", key, symbolCounter[key]);
            }

        }
    }
}
