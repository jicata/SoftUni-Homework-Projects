using System;


namespace Blobs.Interfaces
{
    /// <summary>
    /// Defines methods for the Behaviour class.
    /// </summary>
   public interface IBehaviour : ITriggerable
    {
       void Apply(IBlob blob);
    }
}
