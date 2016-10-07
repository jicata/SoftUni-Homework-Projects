namespace _04_BalancedOrderedSet
{
    using System;


    class Program
    {
        static void Main()
        {
            var balancedSet = new AVLTreeBalancedSet<int>();
            balancedSet.Add(17);
            balancedSet.Add(9);
            balancedSet.Add(12);
            balancedSet.Add(19);
            balancedSet.Add(6);
            balancedSet.Add(25);
            balancedSet.Add(5);

            foreach (var item in balancedSet)
            {
                Console.WriteLine(item);
            }

        }
    }
}
