namespace LoggerLib.Interfaces
{
    public interface ILogger
    {
        IAppender Appender { get; }

        void LogError(string message);

        void LogInfo(string message);
    }
}
