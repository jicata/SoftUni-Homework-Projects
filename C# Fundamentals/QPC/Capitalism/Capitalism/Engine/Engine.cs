using System;
using System.Collections.Generic;
using Capitalism.Contracts;


namespace Capitalism.Engine
{
    public class Engine : IEngine 
    {
        public Engine(IReader reader, IWriter writer)
        {
            this.CommandExecutioner = new CommandExecutioner(this);
            this.CommandHandler = new CommandHandler(reader,writer);
            this.Companies = new List<ICompany>();
        }
        public ICommandExecutioner CommandExecutioner { get; set; }
        public ICommandHandler CommandHandler { get; }
        public ICollection<ICompany> Companies { get; set; }

        public void Run()
        {
            while (true)
            {
                string[] commandArgs = CommandHandler.InterpretCommand();
                CommandExecutioner.ExecuteCommand(commandArgs);

            }
        }
    }
}
