using System;


namespace Capitalism.Contracts
{
    public interface ICommandExecutioner
    {
        IEngine Engine { get; }
        void ExecuteCommand(string[] command);
    }
}
