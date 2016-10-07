namespace _01_DistanceBetweenVertices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;

    class Program
    {
        static void Main()
        {
            Console.ReadLine();
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            string graphInfo = Console.ReadLine();
            while (graphInfo != "Distances to find:")
            {
                int indexOf = graphInfo.IndexOf('>');
                int vertex = int.Parse(graphInfo.Substring(0, 2).Trim());
                string[] vertexChildren = graphInfo.Substring(indexOf + 1).Trim().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                graph.Add(vertex, new List<int>());
                if (vertexChildren.Length > 0)
                {
                    foreach (var vertexChild in vertexChildren)
                    {
                        graph[vertex].Add(int.Parse(vertexChild));
                    }
                }
                graphInfo = Console.ReadLine();
            }
            string distanceToFind = Console.ReadLine();
            while (distanceToFind != "kur")
            {
                int[] nodes = distanceToFind.Split('-').Select(int.Parse).ToArray();
                int sourceNode = nodes[0];
                int destinationNode = nodes[1];
                int steps = FindDistance(graph, sourceNode, destinationNode);
                Console.WriteLine("{" + sourceNode + ", " + destinationNode + "}" + " -> " + steps);
                distanceToFind = Console.ReadLine();
            }
            // PrintGraph(graph);
        }

        private static int FindDistance(Dictionary<int, List<int>> graph, int sourceNode, int destinationNode)
        {
            bool discovered = false;
            Dictionary<int, int> pathsToRecover = new Dictionary<int, int>();
            Queue<int> bfs = new Queue<int>();
            HashSet<int> visitedNodes = new HashSet<int>();

            bfs.Enqueue(sourceNode);
            while (bfs.Count > 0 && !discovered)
            {

                int currentNode = bfs.Dequeue();
                foreach (var child in graph[currentNode])
                {
                    if (!visitedNodes.Contains(child))
                    {
                        pathsToRecover[child] = currentNode;
                        if (child == destinationNode)
                        {
                            discovered = true;
                            break;
                        }
                        bfs.Enqueue(child);
                        visitedNodes.Add(child);
                    }
                    
                }

            }
            int count = 1;
            if (pathsToRecover.ContainsKey(destinationNode))
            {
                int lastNode = pathsToRecover[destinationNode];
                while (lastNode != sourceNode)
                {
                    count++;
                    lastNode = pathsToRecover[lastNode];
                }
                return count;
            }
            return -1;

        }

        private static void PrintGraph(Dictionary<int, List<int>> graph)
        {
            foreach (var vertex in graph)
            {
                Console.Write(vertex.Key + " -> ");
                Console.WriteLine(string.Join(", ", vertex.Value));
            }
        }
    }
}
