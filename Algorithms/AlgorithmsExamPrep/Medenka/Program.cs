namespace Medenka
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Program
    {
        static List<int> set = new List<int>(); 
        static StringBuilder sb =new StringBuilder();
        static void Main()
        {
            int[] medenkaDetails = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int nutsCount = -1;
            for (int i = 0; i < medenkaDetails.Length; i++)
            {
                if (medenkaDetails[i] == 1)
                {
                    nutsCount++;
                }
            }
            int[] brokenMedenka = new int[medenkaDetails.Length+nutsCount];
            BreakIt(medenkaDetails, 0);
            Console.WriteLine(sb);
        }

        private static void BreakIt(int[] medenkaDetails, int index)
        {
            
        }

        private static void Print(int[] brokenMedenka)
        {
            // ne zqpai
        }
    }
}
