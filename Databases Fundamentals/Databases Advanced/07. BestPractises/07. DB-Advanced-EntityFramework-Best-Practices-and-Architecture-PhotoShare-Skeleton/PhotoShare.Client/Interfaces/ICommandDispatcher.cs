namespace PhotoShare.Client.Interfaces
{
    public interface ICommandDispatcher
    {
        IExecutable DispatchCommand(string commandName, string[] commandParameters);
    }
}
