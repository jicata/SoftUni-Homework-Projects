namespace LoggerLib.Models
{
    using System;
    using Interfaces;

    public class SimpleLayout : ILayout
    {
        public string FormatMessage(string message, string type)
        {
            // formatting <date-time> - <report type/level> - <message>
            return $"{DateTime.Now} - {type} - {message}";
        }
    }
}
