namespace PhotoShare.Client.Core.Commands
{
    using Attributes;
    using Data;
    using Models;
    using System;
    using System.Data.Entity;

    public class ExitCommand : Command
    {
        public ExitCommand(string[] data) : base(data)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);
            return "Bye-bye";
        }
    }
}
