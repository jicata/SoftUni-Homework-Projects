using System;


namespace Blobs.Interfaces
{
    /// <summary>
    /// Defines properties and methods for the Blob class.
    /// </summary>
    public interface IBlob : IAttacker, IDestroyable, IUpdateable
    {
        string Name { get; set; }
        int CurrentHealth { get; set; }
        int CurrentDamage { get; set; }
        IBehaviour Behaviour { get; }
        IAttack Attack { get; }
    }
}
