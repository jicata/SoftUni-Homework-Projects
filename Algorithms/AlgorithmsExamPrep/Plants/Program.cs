namespace PlantsOptimized
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Solution
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var plants = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var proximityStack = new Stack<int>();
            var days = new int[plants.Length];
            proximityStack.Push(0);
            for (int x = 1; x < plants.Length; x++)
            {
                int maxDays = 0;
               
                while (proximityStack.Count > 0 && plants[proximityStack.Peek()] >= plants[x])
                {
                    maxDays = Math.Max(days[proximityStack.Pop()], maxDays);
                }

                if (proximityStack.Count > 0)
                {
                    days[x] = maxDays + 1;
                }

                proximityStack.Push(x);
            }

            Console.WriteLine(days.Max());
        }
    }
}