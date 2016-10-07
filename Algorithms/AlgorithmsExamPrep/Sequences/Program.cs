namespace Sequences
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Program
    {
        public static List<int> sequences = new List<int>(); 
        public static StringBuilder sb = new StringBuilder();
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            GiveMeSequence(n, 0);
            Console.WriteLine(sb);
        }

        private static void GiveMeSequence(int maxSum, int currentSum)
        {
          
            for (int i = 1; i <= maxSum; i++)
            {
                if (currentSum + i <= maxSum)
                {
                    sequences.Add(i);
                    Print();
                    GiveMeSequence(maxSum, currentSum + i);

                    sequences.RemoveAt(sequences.Count-1);
                }
                else
                {
                    break;
                }
                
            }
        }

        private static void Print()
        {
           sb.AppendLine(string.Join(" ", sequences));
        }
    }
}
