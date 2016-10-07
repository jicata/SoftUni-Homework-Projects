namespace _02_SortWordss
{
    using System;
    using System.Collections.Generic;

    static class Program
    {
        public static void Main()
        {
            string initialInput = Console.ReadLine();
            string[] input = new string[0];
            if (!string.IsNullOrEmpty(initialInput))
            {
                input = initialInput.Split();
            }

            List<string> words = new List<string>();


            for (int i = 0; i < input.Length; i++)
            {
                words.Add(input[i]);
            }
            words.Sort();

            Console.WriteLine(string.Join(", ", words));
        }
    }
}
