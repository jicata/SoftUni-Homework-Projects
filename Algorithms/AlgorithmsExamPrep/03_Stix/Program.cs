namespace _03_Stix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static List<int> removedNodes = new List<int>(); 
        static void Main()
        {
            int sticks = int.Parse(Console.ReadLine());
            int relationships = int.Parse(Console.ReadLine());
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            for (int i = 0; i < sticks; i++)
            {
                graph.Add(i, new List<int>());
            }
            for (int i = 0; i < relationships; i++)
            {
                int[] relationInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int predecessor = relationInfo[0];
                int chid = relationInfo[1];
                graph[predecessor].Add(chid);
            }
             Dictionary<int, int> predecessorsCount = new Dictionary<int, int>();
            foreach (var node in graph)
            {
                if (!predecessorsCount.ContainsKey(node.Key))
                {
                    predecessorsCount.Add(node.Key, 0);
                }
                foreach (var childNode in node.Value)
                {
                    if (!predecessorsCount.ContainsKey(childNode))
                    {
                        predecessorsCount.Add(childNode, 0);
                    }
                    predecessorsCount[childNode]++;
                }
            }
            //foreach (var item in predecessorsCount)
            //{
            //    Console.WriteLine("Node {0} has {1} predecessors", item.Key, item.Value);
            //}
            RemoveNodes(graph, predecessorsCount);
            Console.WriteLine(string.Join(" ", removedNodes));
        }
        public static void RemoveNodes(Dictionary<int, List<int>> graph, Dictionary<int,int> predecessorsCount)
        {
            while (true)
            {
                List<int> nodesToRemove = graph.Keys.Where(n => predecessorsCount[n] == 0).ToList();
               // int? nodeToRemove = graph.Keys.FirstOrDefault(n => predecessorsCount[n] == 0);
                if (nodesToRemove.Count == 0)
                {
                    break;
                }
                int? nodeToRemove = nodesToRemove.Max();
                if (nodeToRemove == null)
                {
                    break;
                }
                foreach (var childNode in graph[nodeToRemove.Value])
                {
                    predecessorsCount[childNode]--;
                }
                graph.Remove(nodeToRemove.Value);
                removedNodes.Add(nodeToRemove.Value);
            }
            if (graph.Count > 0)
            {
                Console.WriteLine("Cannot lift all sticks");
            }
        }
    }
}
