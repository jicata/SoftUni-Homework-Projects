namespace _01_FindTheRoot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int numberOfNodes = int.Parse(Console.ReadLine());
            int numberOfEdges = int.Parse(Console.ReadLine());
            List<int>[] graph = new List<int>[numberOfNodes];
            bool[] relationships = new bool[numberOfNodes];
            for (int i = 0; i < numberOfEdges; i++)
            {
                int[] edge = 
                    Console.ReadLine()
                        .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                int parent = edge[0];
                int child = edge[1];
                relationships[child] = true;
                graph[i] = new List<int>()
                {
                    parent,child
                };
            }
            List<int> roots = new List<int>();
            for (int i = 0; i < relationships.Length; i++)
            {
                if (relationships[i] == false)
                {
                    roots.Add(i);
                }
            }
            if (roots.Count == 0)
            {
                Console.WriteLine("No root!");
            }
            else if (roots.Count == 1)
            {
                Console.WriteLine(roots[0]);
            }
            else if (roots.Count > 1)
            {
                Console.WriteLine("Multiple roots!");
            }
            
        }
     
       
    }
}
