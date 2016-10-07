namespace _02_ProcessorScheduling
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            string[] firstLine = Console.ReadLine().Split(':');
            int taskNumber = int.Parse(firstLine[1].Trim());
            SortedDictionary<int, List<int>> tasksByDeadline = new SortedDictionary<int, List<int>>();
            List<int> tasksNumerated = new List<int>();
            for (int i = 0; i < taskNumber; i++)
            {
                string[] taskArgs = Console.ReadLine().Split('-');
                int taskValue = int.Parse(taskArgs[0]);
                int taskDeadline = int.Parse(taskArgs[1]);
                if (!tasksByDeadline.ContainsKey(taskDeadline))
                {
                    tasksByDeadline[taskDeadline] = new List<int>();
                }
                tasksByDeadline[taskDeadline].Add(taskValue);
                tasksNumerated.Add(taskValue);

            }
            foreach (var deadline in tasksByDeadline)
            {
                Console.WriteLine("Deadline - {0}, Tasks : {1}", deadline.Key, string.Join(" ", deadline.Value));
            }
            List<int> optimalSchedule = new List<int>();
            int totalValue = 0;
            
            for (int i = 1; i <= tasksByDeadline.Keys.Max(); i++)
            {
                int currentIndex = i;
                while(tasksByDeadline[currentIndex].Count == 0 && currentIndex < taskNumber)
                {
                    currentIndex++;
                }
                int currentBest = tasksByDeadline[currentIndex].Max();

                for (int j = i + 1; j < tasksByDeadline.Keys.Max(); j++)
                {
                    int bestCandidate = tasksByDeadline[j].Max();
                    if (bestCandidate - currentBest > currentBest)
                    {
                        currentBest = bestCandidate;
                        currentIndex = j;
                    }
                }
                optimalSchedule.Add(tasksNumerated.IndexOf(currentBest)+1);
                totalValue += currentBest;
                tasksByDeadline[currentIndex].Remove(currentBest);
            }
            Console.WriteLine("Optimal schedule: {0}",string.Join(" -> ", optimalSchedule));
            Console.WriteLine("Total value: {0}", totalValue);
        }
    }
}
