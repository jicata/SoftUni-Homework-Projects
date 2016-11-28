using PhotoShare.Client.Interfaces;
using System;


namespace PhotoShare.Client.Core
{
    class Engine : IRunnable
    {
        private ICommandDispatcher commandDispatcher;
        private IReader reader;
        private IWriter writer;
        public Engine(ICommandDispatcher commandDispatcher, IReader reader, IWriter writer)
        {
            this.commandDispatcher = commandDispatcher;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run(string start)
        {
            Console.WriteLine("Program started");
            while (false)
            {
                try
                {
                    string input = reader.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    string result = this.commandDispatcher
                        .DispatchCommand(commandName, data)
                        .Execute();
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    writer.WriteLine(e.Message);
                }
            }
        }
    }
}
