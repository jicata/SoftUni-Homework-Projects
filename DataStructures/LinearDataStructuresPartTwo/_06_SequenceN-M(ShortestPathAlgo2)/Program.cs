namespace _06_Sequence_N_M_Shortest_path__algo2_
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int[] nANDm = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            int n = nANDm[0];
            int m = nANDm[1];

            if (n >= m)
            {
                Console.WriteLine("(no solution)");
                return;
            }
            Queue<Item> items = new Queue<Item>();
            items.Enqueue(new Item(n));
            int count = 0;
            while (items.Count > 0)
            {
                var item = items.Dequeue();
                if (item.value < m)
                {
                    items.Enqueue(new Item(item.value + 1, item)); 
                    items.Enqueue(new Item(item.value + 2, item));
                    items.Enqueue(new Item(item.value * 2, item));
                }
                if (item.value == m)
                {
                    PrintItem(item);
                    break;
                }
                count++;
            }
            Console.WriteLine(count+1);
        }

        private static void PrintItem(Item item)
        {
            List<long> kurac =new List<long>();
            while (item != null)
            {
                kurac.Add(item.value);
                item = item.prevItem;
            }
            kurac.Reverse();
            Console.WriteLine(string.Join(" -> ", kurac));
        }
    }

    public class Item
    {
        public long value;
        public Item prevItem;

        public Item(long value, Item prevItem = null)
        {
            this.value = value;
            this.prevItem = prevItem;
        }

        public override string ToString()
        {
            return this.value.ToString();
        }
    }
}
