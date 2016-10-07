using System;


namespace Blobs.Interfaces
{
    /// <summary>
    /// Defines methods related to activating a certain instance of the Behaviour class for a given instance of the Blob class.
    /// </summary>
    public interface ITriggerable
    {
        bool IsTriggered { get; set; }
        void Trigger(IBlob blob);
    }
}
