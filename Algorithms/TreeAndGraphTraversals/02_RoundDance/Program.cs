namespace _02_RoundDance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int numberOfFriendshipsAkaEdges = int.Parse(Console.ReadLine());
            int danceLeaderAkaRoYaL = int.Parse(Console.ReadLine());
            List<GraphNode> nodes = new List<GraphNode>();

            for (int i = 0; i < numberOfFriendshipsAkaEdges; i++)
            {
                int[] graphEdge = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var firstNode = nodes.FirstOrDefault(x => x.value == graphEdge[0]);
                if (firstNode == null)
                {
                    firstNode = new GraphNode(graphEdge[0]);
                    nodes.Add(firstNode);
                }
                var secondNode = nodes.FirstOrDefault(x => x.value == graphEdge[1]);
                if (secondNode == null)
                {
                   secondNode = new GraphNode(graphEdge[1]);
                   nodes.Add(secondNode);
                }

                firstNode.friends.Add(secondNode);
                secondNode.friends.Add(firstNode);
            }
            var leaderNode = nodes.First(x => x.value == danceLeaderAkaRoYaL);
            int maxCount = int.MinValue;
            int currentCount = 1;
            List<int> dancingNodes = new List<int>();
            List<List<int>> longestDancingNodes = new List<List<int>>();
            
            for (int i = 0; i < leaderNode.friends.Count; i++)
            {
                var currentNode = leaderNode.friends[i];
                Stack<GraphNode> myStack = new Stack<GraphNode>();
                myStack.Push(currentNode);
                dancingNodes.Add(leaderNode.value);
                while (myStack.Count > 0)
                {
                    var node = myStack.Pop();
                    dancingNodes.Add(node.value);
                    currentCount++;
                    if (node.friends.Count - 1 > 0)
                    {
                        var friend = node.friends.First(x => x.value != node.value && x.value != leaderNode.value);
                        myStack.Push(friend);
                    }
                   
                }
                if (currentCount >= maxCount)
                {
                    maxCount = currentCount;
                    longestDancingNodes.Add(dancingNodes);
                    
                }
                currentCount = 1;
                dancingNodes = new List<int>();
            }
            Console.WriteLine();
            Console.WriteLine("Longest path is {0} steps long", maxCount);
            Console.WriteLine();
            foreach (var dance in longestDancingNodes.Where(x=>x.Count == maxCount))
            {
                Console.WriteLine(string.Join(" -> ", dance));
            }
           
        }
    }
}
