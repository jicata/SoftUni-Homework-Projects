namespace _01_CollectResources
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            string pattern = @"([a-zA-Z]+)_?(\d+)?\b";
            Regex resourceMatcher = new Regex(pattern);
            List<Resource> resources = new List<Resource>();
            string input = Console.ReadLine();

            var matches = resourceMatcher.Matches(input);
            foreach (Match match in matches)
            {
                string resourceName = match.Groups[1].Value;
                int resourceQuantity = 1;
                if (match.Groups[2].Value != "")
                {
                    resourceQuantity = int.Parse(match.Groups[2].Value);
                }
               
                resources.Add(new Resource(resourceName, resourceQuantity));
            }
            int n = int.Parse(Console.ReadLine());
            int maxTotalQuantity = 0;
            int maxQuantityCurrentPath = 0;

            for (int i = 0; i < n; i++)
            {
                int[] jumpCoordinates = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
                int startIndex = jumpCoordinates[0];
                int steps = jumpCoordinates[1];

                Resource currentResource = resources[startIndex];
                while (!currentResource.visited)
                {

                    if (currentResource.name == "stone" || currentResource.name == "gold" ||
                        currentResource.name == "wood" || currentResource.name == "food")
                    {
                        currentResource.visited = true;
                        maxQuantityCurrentPath += currentResource.quantity;
                    }
                    startIndex = (startIndex + steps) % resources.Count;
                    currentResource = resources[startIndex];

                }
                if (maxQuantityCurrentPath > maxTotalQuantity)
                {
                    maxTotalQuantity = maxQuantityCurrentPath;
                }
                foreach (var resource in resources)
                {
                    resource.visited = false;
                }
                maxQuantityCurrentPath = 0;
            }
            Console.WriteLine(maxTotalQuantity);
        }
    }

    public class Resource
    {
        public string name;
        public int quantity;
        public bool visited;

        public Resource(string name, int quantity)
        {
            this.name = name;
            this.quantity = quantity;
        }

        public override string ToString()
        {
            string result = this.name + "_" + this.quantity;
            return result;
        }
    }
}
