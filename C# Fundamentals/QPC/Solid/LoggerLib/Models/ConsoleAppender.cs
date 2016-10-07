namespace LoggerLib.Models
{
    using System;
    using Interfaces;

    public class ConsoleAppender : IAppender
    {
        private ILayout layout;

        public ConsoleAppender(ILayout layout)
        {
            this.Layout = layout;
        }

        public ILayout Layout
        {
            get { return this.layout; }
            set { this.layout = value; }
        }

        public void Append(string message, string messageType)
        {
            var logToAppend = this.FormatAccordingToLayout(message, messageType);

            Console.WriteLine(logToAppend);
        }

        private string FormatAccordingToLayout(string message, string messageType)
        {
            string logToAppend = this.Layout.FormatMessage(message, messageType);
            return logToAppend;
        }
    }
}
