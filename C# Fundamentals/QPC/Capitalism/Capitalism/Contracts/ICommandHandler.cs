using System;


namespace Capitalism.Contracts
{
    public interface ICommandHandler
    {
        IReader Reader { get; }
        IWriter Writer { get; }
        string[] InterpretCommand();
    }
}
