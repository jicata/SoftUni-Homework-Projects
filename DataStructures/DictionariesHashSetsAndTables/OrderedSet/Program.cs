namespace OrderedSet
{
    using System;

    class Program
    {
        static void Main()
        {
            var set = new BinaryTreeOrderedSet<int>();
            set.Add(17);
            set.Add(9);
            set.Add(12);
            set.Add(19);
            set.Add(6);
            set.Add(25);
            set.Add(11);
            set.Add(13);
            set.Add(18);
            set.Add(18);
            set.Remove(25);
          
            Console.WriteLine(set.Count);
            Console.WriteLine();

            foreach (var item in set)
            {
                Console.WriteLine(item);
            }

        }
    }
}
