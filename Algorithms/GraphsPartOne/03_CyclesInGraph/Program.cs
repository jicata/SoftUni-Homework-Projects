namespace _03_CyclesInGraph
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;

    class Program
    {
        private static HashSet<char> visited = new HashSet<char>();
        private static HashSet<char> currentlyVisited = new HashSet<char>();
        private static LinkedList<char> sorted = new LinkedList<char>();
        private static Dictionary<char, List<char>> graph = new Dictionary<char, List<char>>();
        static void Main()
        {

            List<char> nodes = new List<char>();
            string inputVertices = Console.ReadLine();
            while (!string.IsNullOrEmpty(inputVertices))
            {
                string[] vertexInfo = inputVertices.Split('-');
                char parentNode = char.Parse(vertexInfo[0].Trim());
                char childNode = char.Parse(vertexInfo[1].Trim());
                nodes.Add(parentNode);
                nodes.Add(childNode);
                if (!graph.ContainsKey(parentNode))
                {
                    graph.Add(parentNode, new List<char>());
                }
                if (!graph.ContainsKey(childNode))
                {
                    graph.Add(childNode, new List<char>());
                }
                graph[parentNode].Add(childNode);
                inputVertices = Console.ReadLine();
            }
            foreach (var vertex in graph.Keys)
            {
                try
                {
                    TopologicalDFS(vertex);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }

            }
            Console.WriteLine("Acyclic: Yes");
            //DisplayGraph(graph);
           // Console.WriteLine(string.Join(" ", sorted));
        }

        private static void TopologicalDFS(char vertex)
        {
            if (currentlyVisited.Contains(vertex))
            {
                throw new InvalidOperationException("Acyclic: No");
            }
            if (!visited.Contains(vertex))
            {
                currentlyVisited.Add(vertex);
                visited.Add(vertex);
                foreach (var child in graph[vertex])
                {

                    TopologicalDFS(child);

                }
                currentlyVisited.Remove(vertex);
                sorted.AddFirst(vertex);
            }
        }

        private static void DisplayGraph(Dictionary<char, List<char>> graph)
        {
            foreach (var vertex in graph)
            {
                Console.WriteLine("{0} -> {1}", vertex.Key, string.Join(", ", vertex.Value));
            }
        }
    }
}
