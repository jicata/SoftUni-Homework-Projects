namespace ShortestPath
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.Win32;

    class Program
    {
        private static StringBuilder map;
        private static List<int> starIndices;
        static char[] options = new[] { 'L', 'R', 'S' };
        private static bool[] used = new bool[3];
        private static StringBuilder result = new StringBuilder();
        private static int totalCounter = 0;
        static void Main()
        {
            map = new StringBuilder(Console.ReadLine());

            starIndices = new List<int>();
            for (int i = 0; i < map.Length; i++)
            {
                if (map[i] == '*')
                {
                    starIndices.Add(i);
                }
            }

            int index = 0;
            char[] variations = new char[starIndices.Count];
            FindPaths(variations, index);
            Console.WriteLine(totalCounter);
            Console.Write(result);

        }

        private static void FindPaths(char[] variations, int index)
        {
            if (index == variations.Length)
            {
                Print(variations);
                totalCounter++;
                return;
            }
            for (int i = 0; i < 3; i++)
            {
                
                    used[i] = true;
                    variations[index] = options[i];
                    FindPaths(variations, index+1);
                    used[i] = false;
                
            }
           
        }

        private static void Print(char[] variations)
        {
            StringBuilder sb = new StringBuilder();
            
            int counter = 0;
            for (int i = 0; i < map.Length; i++)
            {
                if (map[i] == '*')
                {
                    sb.Append(variations[counter]);
                    counter++;
                }
                else
                {
                    sb.Append(map[i]);
                }
            }
            result.AppendLine(sb.ToString());
         
        }
    }
}
