namespace SubirameResursi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            string[] resourceArray = Console.ReadLine().Split();

            for (int i = 0; i < resourceArray.Length; i++)
            {
                if (!resourceArray[i].Contains("_"))
                {
                    resourceArray[i] += "_1";
                }

            }
            int steps = int.Parse(Console.ReadLine());
            int[] collectedResources = new int[steps];
            List<int> visitedIndices = new List<int>();

            for (int i = 0; i < steps; i++)
            {
                int[] startAndStep = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int start = startAndStep[0];
                int step = startAndStep[1];

                int currentStep = start;
                while (!visitedIndices.Contains(currentStep))
                {
                    string[] resourceAndQuantity = resourceArray[currentStep].Split('_');
                    string resource = resourceAndQuantity[0];
                    string quantity = resourceAndQuantity[1];
                    if (IsValidResource(resource))
                    {
                        visitedIndices.Add(currentStep);
                        collectedResources[i] += int.Parse(quantity);
                    }
                    currentStep = (currentStep + step) % resourceArray.Length;


                }
                visitedIndices.Clear();
            }
            Console.WriteLine(collectedResources.Max());
        }

        private static bool IsValidResource(string resource)
        {
            bool isValid = false;
            if (resource == "wood" || resource == "gold" || resource == "food" || resource == "stone")
            {
                isValid = true;
            }
            return isValid;
        }
    }
}
