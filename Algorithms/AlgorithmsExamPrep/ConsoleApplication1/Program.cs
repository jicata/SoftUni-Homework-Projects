namespace ConsoleApplication1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;

    class Program
    {
        static Dictionary<char, int> repeatingLetters = new Dictionary<char, int>();
        static List<char> perms = new List<char>(); 
        static HashSet<char> used = new HashSet<char>();
        static void Main()
        {
            string input = Console.ReadLine();

            char[] letters = new char[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                letters[i] = input[i];
                if (!repeatingLetters.ContainsKey(input[i]))
                {
                    repeatingLetters[input[i]] = 0;
                }
                repeatingLetters[input[i]]++;
            }


            FindThePermutations(repeatingLetters.Keys.ToArray(), 0);
        }

        private static void FindThePermutations(char[] letters, int index)
        {
            if (index >= letters.Length)
            {
                Print(letters);
                return;
            }
            FindThePermutations(letters,index+1);
            for (int i = index+1; i < letters.Length; i++)
            {
                Swap(ref letters[i], ref letters[index]);
                FindThePermutations(letters,index+1);
                Swap(ref letters[i], ref letters[index]);
            }

        }

        private static void Swap(ref char p0, ref char p1)
        {
            var oldp0 = p0;
            p0 = p1;
            p1 = oldp0;
        }

        private static void Print(char[] list)
        {
            foreach (var item in list)
            {
                for (int i = 0; i < repeatingLetters[item]; i++)
                {
                    Console.Write(item);
                }
            }
            Console.WriteLine();
        }
    }
}
