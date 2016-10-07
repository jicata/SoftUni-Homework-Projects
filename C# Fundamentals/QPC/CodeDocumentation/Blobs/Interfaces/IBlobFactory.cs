using System;


namespace Blobs.Interfaces
{
    /// <summary>
    /// Defines methods for creating instances of the Blob class.
    /// </summary>
    public interface IBlobFactory
    {
        IBlob CreateBlob(string name, int health, int damage, IBehaviour behaviour, IAttack attack);
    }
}
