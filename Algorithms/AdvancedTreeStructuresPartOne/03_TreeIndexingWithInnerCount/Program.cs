namespace _03_TreeIndexingWithInnerCount
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

            string userInput = Console.ReadLine();
            while (userInput != "end")
            {
                try
                {
                    int index = int.Parse(userInput);
                    int getRekt = tree[index];
                    Console.WriteLine("Number at index {0} is {1}", index, getRekt);
                    

                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
                userInput = Console.ReadLine();

            }



        }

    }
}
