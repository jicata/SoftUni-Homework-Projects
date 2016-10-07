namespace _05_Sorting
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Net.Configuration;

    class Program
    {
        // just fucking around honestly
        // the "algorithm" works for the basic cases
        // but fails marvelously at the advanced ones
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rotation = int.Parse(Console.ReadLine());

            int[] sortedNumbers = new int[numbers.Length];
            Array.Copy(numbers, sortedNumbers, numbers.Length);
            Array.Sort(sortedNumbers);


            Dictionary<string, int> uniqueSequences = new Dictionary<string, int>();
            bool isSorted = Enumerable.SequenceEqual(numbers, sortedNumbers);
            bool flag = false;
           
            if (isSorted)
            {
                Console.WriteLine(0);

            }

            else
            {
                Queue<Sequence> sequences = new Queue<Sequence>();
                sequences.Enqueue(new Sequence(numbers, 0));
                Stopwatch sw = new Stopwatch();
                sw.Start();
                while (sequences.Count> 0)
                {
                    var currentSequence = sequences.Dequeue();
                    for (int i = 0; i < currentSequence.Collection.Length - (rotation - 1); i++)
                    {
                        int[] tempArray = new int[currentSequence.Collection.Length];

                        Array.Copy(currentSequence.Collection, tempArray, tempArray.Length);
                        Array.Reverse(tempArray, i, rotation);
                        isSorted = Enumerable.SequenceEqual(tempArray, sortedNumbers);
                        if (isSorted)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Number of rotation required : {0}", currentSequence.NumberOfRotations + 1);
                            Console.WriteLine();
                            flag = true;
                            break;
                        }


                        if (!uniqueSequences.ContainsKey(string.Join(", ", tempArray)))
                        {
                            uniqueSequences.Add(string.Join(", ", tempArray), currentSequence.NumberOfRotations + 1);
                            sequences.Enqueue(new Sequence(tempArray, currentSequence.NumberOfRotations + 1));
                        }

                    }
                    if (flag)
                    {
                        break;
                    }
                    //if (sequences.Count%100000 == 0)
                    //{
                    //    Console.WriteLine(currentSequence.NumberOfRotations);
                    //}

                }
                if (!flag)
                {
                    Console.WriteLine("no");
                }

            }
        }

     
    }
}
