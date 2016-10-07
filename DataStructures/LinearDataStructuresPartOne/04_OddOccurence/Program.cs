namespace _04_OddOccurence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            List<int> input = Console.ReadLine().Split().Select(x => int.Parse(x)).ToList();

            List<int> uniqueNumbers = new List<int>();
            List<int> readyToTrash = new List<int>();
            bool isUnique = false;
            int occurences = 1;
            for (int i = 0; i < input.Count; i++)
            {
                int number = input[i];
                if (!uniqueNumbers.Contains(number))
                {
                    uniqueNumbers.Add(number);
                    isUnique = true;
                    for (int j = i+1; j < input.Count; j++)
                    {
                        if (input[j] == number)
                        {
                            occurences ++;
                        }
                    }
                }
                if (isUnique && occurences%2 != 0)
                {
                    readyToTrash.Add(number);
                }
                occurences = 1;
                isUnique = false;
            }
            foreach (var trashNumber in readyToTrash)
            {
                input.RemoveAll(x => x == trashNumber);
            }
            Console.WriteLine(string.Join(", ", input));
        }
    }
}
