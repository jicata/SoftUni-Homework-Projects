namespace LoggerLib.Models
{
    using Interfaces;

    public class Logger : ILogger
    {
        private IAppender appender;

        public Logger(IAppender appender)
        {
            this.Appender = appender;
        }

        public IAppender Appender
        {
            get { return this.appender; }
            private set { this.appender = value; }
        }

        public void LogError(string message)
        {
           this.appender.Append(message, "Error");
        }

        public void LogInfo(string message)
        {
            this.appender.Append(message, "Info");
        }
    }
}
