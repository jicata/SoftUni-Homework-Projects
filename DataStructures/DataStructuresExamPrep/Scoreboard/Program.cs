namespace Scoreboard
{
    using System;

    class Program
    {
        static void Main()
        {
            var scoreCollection = new ScoresCollection();
            string command = Console.ReadLine();

            while (command != "End")
            {
                if (string.IsNullOrEmpty(command))
                {
                    command = Console.ReadLine();
                    continue;
                }
                Console.WriteLine(scoreCollection.ProcessCommand(command));
                command = Console.ReadLine();
            }
        }
    }
}
