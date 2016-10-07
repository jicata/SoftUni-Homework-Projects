namespace LoggerLib.Interfaces
{
    public interface IAppender
    {
        ILayout Layout { get; }

        void Append(string message, string messageType);
    }
}
