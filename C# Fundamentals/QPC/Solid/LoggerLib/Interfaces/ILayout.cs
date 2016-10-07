namespace LoggerLib.Interfaces
{
    public interface ILayout
    {
        string FormatMessage(string message, string messageType);
    }
}
