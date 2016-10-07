using System;

using Capitalism.Contracts;

namespace Capitalism.Engine
{
    public class OutputWriter : IWriter
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
