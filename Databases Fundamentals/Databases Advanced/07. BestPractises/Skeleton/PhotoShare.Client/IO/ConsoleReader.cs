namespace PhotoShare.Client.IO
{
    using System;
    using Interfaces;
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
