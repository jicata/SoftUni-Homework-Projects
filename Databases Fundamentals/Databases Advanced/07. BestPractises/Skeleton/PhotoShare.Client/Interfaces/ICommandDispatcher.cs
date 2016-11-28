namespace PhotoShare.Client.Interfaces
{
    using Data.Contracts;

    public interface ICommandDispatcher
    {
        IUnitOfWork UnitOfWork { get; }
        IExecutable DispatchCommand(string commandName, string[] commandParameters);
    }
}
