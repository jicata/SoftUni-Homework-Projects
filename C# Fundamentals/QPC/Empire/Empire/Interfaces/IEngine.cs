using System;


namespace Empire.Engine
{
    public interface IEngine
    {
        IOutputWriter Writer { get; }
        IInputReader Reader { get; }
    }
}
