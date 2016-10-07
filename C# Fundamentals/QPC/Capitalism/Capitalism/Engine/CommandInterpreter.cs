using System;
using Capitalism.Contracts;


namespace Capitalism.Engine
{
    public class CommandHandler : ICommandHandler
    {
        public CommandHandler(IReader reader, IWriter writer)
        {
            this.Reader = reader;
            this.Writer = writer;
        }
        public IReader Reader { get; }
        public IWriter Writer { get; }
        public string[] InterpretCommand()
        {
            string[] commandArgs = Reader.Read().Split();
            return commandArgs;
        }
    }
}
