using System;


namespace Empire.Engine
{
    public class InputReader : IInputReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
