using System;


namespace Blobs.Interfaces
{
    /// <summary>
    /// Defines the Health property. Used by defending entities.
    /// </summary>
    public interface IDestroyable
    {
        int Health { get; set; }
    }
}
