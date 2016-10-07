using System;

namespace Blobs.Interfaces
{
    /// <summary>
    /// Defines the Damage property. Used by attacking entities.
    /// </summary>
    public interface IAttacker
    {
        int Damage { get; }
    }
}
