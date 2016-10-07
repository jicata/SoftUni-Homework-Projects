namespace _04_LongestPathInAtree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;


    class Program
    {
        static void Main()
        {
           
            int numberOfNodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());
            List<TreeNode> tree = new List<TreeNode>();

            for (int i = 0; i < edges; i++)
            {
                int[] edge = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var parent = tree.FirstOrDefault(x => x.Value == edge[0]);
                var child = tree.FirstOrDefault(x => x.Value == edge[1]);


                if (parent == null)
                {
                    if (child == null)
                    {
                        child = new TreeNode(edge[1]);
                        tree.Add(new TreeNode(edge[0], child));
                        tree.Add(child);
                    }
                    else
                    {
                        tree.Add(new TreeNode(edge[0], child));
                        tree.Add(child);
                    }


                }
                else
                {
                    if (child == null)
                    {
                        child = new TreeNode(edge[1]);
                        parent.Children.Add(child);
                        child.Parent = parent;
                        tree.Add(child);
                    }
                    else
                    {
                        child.Parent = parent;
                        parent.Children.Add(child);

                    }

                }

            }
            int currentSum = 0;
            int maxSum = 0;
            var leaves = FindAllLeaves(tree);
            Console.WriteLine(string.Join(", ", leaves.Select(x=>x.Value).ToList()));
            Dictionary<int, List<TreeNode>> paths = new Dictionary<int, List<TreeNode>>();
            //List<List<TreeNode>> paths = new List<List<TreeNode>>();
            List<TreeNode> path = new List<TreeNode>();
            List<TreeNode> visited = new List<TreeNode>();
            foreach (var leaf in leaves)
            {
                Stack<TreeNode> nodes = new Stack<TreeNode>();
                nodes.Push(leaf);
                while (nodes.Count > 0)
                {
                    var currentNode = nodes.Pop();
                    //currentSum += currentNode.Value;
                    //path.Add(currentNode);
                    while (currentNode.Parent != null)
                    {
                        currentSum += currentNode.Value;
                        path.Add(currentNode);
                        currentNode = currentNode.Parent;
                        
                    }
                    nodes.Push(currentNode);
                    var temp = new TreeNode[path.Count];
                    path.CopyTo(temp);
                    visited = temp.ToList();
                    while (nodes.Count> 0)
                    {
                        currentNode = nodes.Pop();
                        currentSum += currentNode.Value;
                        if (!visited.Contains(currentNode))
                        {
                            path.Add(currentNode);
                        }
                        
                        visited.Add(currentNode);
                        foreach (var child in currentNode.Children)
                        {
                            if (!visited.Contains(child))
                            {
                                nodes.Push(child);
                            }

                        }
                        if (currentNode.Children.Count == 0)
                        {
                            var pathToAdd = new TreeNode[path.Count];
                            path.CopyTo(pathToAdd);
                            if (!paths.ContainsKey(currentSum))
                            {
                                paths.Add(currentSum,pathToAdd.ToList());
                            }
                            
                            //path.Remove(currentNode);  
                            int amountToRemove = BacktrackingDFS(currentNode, 0, visited, path);
                            if (amountToRemove == 0)
                            {
                                break;
                            }
                            else
                            {
                                currentSum -= amountToRemove;
                            }                         
                            
                        }
                    }
                    //paths.Add(currentSum, path);
                    //Console.WriteLine(currentSum);
                }
                currentSum = 0;
                path = new List<TreeNode>();
            }
            Console.WriteLine();
            var pathsOrdered = paths.OrderByDescending(x => x.Key);
            var longestPath = pathsOrdered.First().Value;

            Console.WriteLine("The max sum path is:");
            Console.WriteLine(string.Join(" -> ", longestPath));
            Console.WriteLine();
            foreach (var PUTEKAVGORATA in paths)
            {
                Console.WriteLine("Sum of path is {0}", PUTEKAVGORATA.Key);
                Console.WriteLine("Steps in path are: {0}", string.Join(" -> ", paths[PUTEKAVGORATA.Key]));
                Console.WriteLine();
            }
                
        }

        public static int BacktrackingDFS(TreeNode node, int sum, List<TreeNode> visitedNodes, List<TreeNode> path)
        {
            sum += node.Value;
            if (node.Parent == null)
            {
                return 0;
            }
            var childrenOfNode = node.Parent.Children;
            for (int i = 0; i < childrenOfNode.Count; i++)
            {
                if (!visitedNodes.Contains(childrenOfNode[i]))
                {
                    path.Remove(node);
                    return sum;
                }
            }
            path.Remove(node);


            return BacktrackingDFS(node.Parent, sum, visitedNodes, path);

        }

        public static IEnumerable<TreeNode> FindAllLeaves(List<TreeNode> tree)
        {
            var allTheLeaves = tree.Where(x => x.Children.Count == 0);
            return allTheLeaves;
        }

        public static int ImprovedBackTrackDFS(TreeNode node, int sum, List<TreeNode> visitedNodes, List<TreeNode> path)
        {

            return 1;
        }
    }
}
