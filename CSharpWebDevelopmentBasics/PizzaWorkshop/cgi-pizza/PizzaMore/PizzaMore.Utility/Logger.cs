namespace PizzaMore.Utility
{
    using System.IO;

    public static class Logger
    {
        public static void Log(string message)
        {
            File.AppendAllText(Constants.LogPath, message);
        }
    }
}
