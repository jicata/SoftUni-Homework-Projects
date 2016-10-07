using System;
using Blobs.Interfaces;


namespace Blobs.Engine
{
    public class OutputWriter: IOutputWriter
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
