namespace _02_CalculateSequenceWIthQueue
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int> myQueue = new Queue<int>();
            List<int> myList = new List<int>();
            myQueue.Enqueue(n);
            int count = 0;
            while (count <= 50)
            {
                int number = myQueue.Dequeue();
                myQueue.Enqueue(number+1);
                myQueue.Enqueue(2*number + 1);
                myQueue.Enqueue(number + 2);

                myList.Add(number);

                count++;
            }
            Console.WriteLine(string.Join(", ", myList));
        }
    }
}
