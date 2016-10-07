namespace _01_RangeInATree
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var tree = new AvlTree<int>();
            int[] numbersToAdd = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < numbersToAdd.Length; i++)
            {
                tree.Add(numbersToAdd[i]);
            }
            int[] toAndFrom = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var elementsInRange = tree.Range(toAndFrom[0], toAndFrom[1]);
            Console.WriteLine(string.Join(", ", elementsInRange));
        }
    }
}
