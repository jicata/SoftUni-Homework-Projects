using System;


namespace Blobs.Interfaces
{
    /// <summary>
    /// Defines methods for writing output
    /// </summary>
    public interface IOutputWriter
    {
        void Write(string message);
    }
}
