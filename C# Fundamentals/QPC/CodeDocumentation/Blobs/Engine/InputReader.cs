using System;
using Blobs.Interfaces;


namespace Blobs.Engine
{
    public class InputReader : IInputReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
