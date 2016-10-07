namespace _06_Sequence_N_M
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int[] nANDm = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            int n = nANDm[0];
            int m = nANDm[1];

            if (n >= m)
            {
                Console.WriteLine("(no solution)");
                return;
            }

            var shortestPath = ShortestPathAlgo1(n, m);
            Console.WriteLine(string.Join("->", shortestPath));
        }

        private static List<long> ShortestPathAlgo1(int n, int m)
        {
            Queue<long> myQueue = new Queue<long>();
            List<long> shortestPath = new List<long>();
            myQueue.Enqueue(n);
            while (myQueue.Count > 0)
            {
                long number = myQueue.Dequeue();
                shortestPath.Add(number);

                //check +1
                long numberPlusOne = number + 1;
                shortestPath.Add(numberPlusOne);

                if (numberPlusOne == m)
                {
                    break;
                }
                myQueue.Enqueue(numberPlusOne);

                //check +2
                long numberPlusTwo = numberPlusOne + 1;
                shortestPath.Add(numberPlusTwo);
                if (numberPlusTwo == m)
                {
                    break;
                }
                myQueue.Enqueue(numberPlusTwo);

                //check times 2
                long numberTimesTwo = number*2;
                shortestPath.Add(numberTimesTwo);
                if (numberTimesTwo == m)
                {
                    break;
                }
                myQueue.Enqueue(numberTimesTwo);
            }
            return shortestPath;
        }
    }
}
