namespace _02_TreeIndexing
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
            while (true)
            {
                try
                {
                    Console.WriteLine(tree[int.Parse(Console.ReadLine())]);
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
                
            }
        }
    }
}
