namespace SequenceWithLimitedSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    class Program
    {
        public static List<int> result = new List<int>(); 
        public static Dictionary<char, int> repeatedLetters = new Dictionary<char, int>(); 
        static void Main()
        {
            //int n = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            foreach (var cha in input)
            {
                if (!repeatedLetters.ContainsKey(cha))
                {
                    repeatedLetters[cha] = 0;
                }
                repeatedLetters[cha]++;
            }
            var letters = repeatedLetters.Keys.ToArray();
            Permute(letters, 0);

        }

        private static void Permute(char[] letters, int index)
        {
            if (index >= letters.Length)
            {
                Print(letters);
                return;
            }
            Permute(letters, index+1);
            for (int i = index+1; i < letters.Length; i++)
            {
                Swap(ref letters[i], ref letters[index]);
                Permute(letters, index+1);
                Swap(ref letters[i], ref letters[index]);
            }
        }

        private static void Swap(ref char p0, ref char p1)
        {
            char oldP0 = p0;
            p0 = p1;
            p1 = oldP0;
        }

        public static void SequenceWithLimitedSum(int currentSum, int sum)
        {
            if (currentSum > sum)
            {
                return;
            }
            if (result.Count > 0)
            {
                Print(result);
            }           
            for (int i = 1; i <= sum; i++)
            {
                currentSum += i;
                result.Add(i);
                SequenceWithLimitedSum(currentSum, sum);
                result.Remove(i);
                currentSum -= i;
            }
        }

        private static void Print(List<int> stringBuilder)
        {
            Console.WriteLine(string.Join(" ", stringBuilder));
        }

        private static void Print(char[] letters)
        {
            foreach (var letter in letters)
            {
                for (int i = 0; i < repeatedLetters[letter]; i++)
                {
                    Console.Write(letter);
                }
            }
            Console.WriteLine();
        }
    }
}
