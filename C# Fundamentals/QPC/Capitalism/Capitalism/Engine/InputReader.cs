using System;

using Capitalism.Contracts;

namespace Capitalism.Engine
{
    public class InputReader: IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
