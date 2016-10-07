namespace Bridges
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static int counter = 0;
        static void Main()
        {
            int[] islands = Console.ReadLine().Split().Select(int.Parse).ToArray();

            bool[] test = new bool[islands.Length];
            int?[] bridges = new int?[islands.Length];
            int? lastBridgeIndex = 0;

            for (int i = 1; i < islands.Length; i++)
            {
                int currentIsland = islands[i];
                for (int j = lastBridgeIndex.Value; j < i; j++)
                {
                    int previousIsland = islands[j];
                    if (currentIsland == previousIsland)
                    {
                        counter++;
                        bridges[i] = j;
                        test[i] = true;
                        test[j] = true;
                        lastBridgeIndex = i;
                        
                        break;
                    }
                }
            }
            
            if (counter > 1)
            {
                Console.WriteLine("{0} bridges found", counter);
            }
            else if (counter == 1)
            {
                Console.WriteLine("{0} bridge found", counter);
            }
            else
            {
                Console.WriteLine("No bridges found");
            }
            
            for (int i = 0; i < islands.Length; i++)
            {
                if (test[i])
                {
                    Console.Write(islands[i] + " ");
                }
                else
                {
                    Console.Write("X ");
                }
            }
            Console.WriteLine();

        }
    }
}
