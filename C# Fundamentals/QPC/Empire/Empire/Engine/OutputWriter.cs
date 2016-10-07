using System;


namespace Empire.Engine
{
    public class OutputWriter : IOutputWriter
    {
        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}
