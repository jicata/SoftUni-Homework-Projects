using System;

namespace Blobs.Interfaces
{
    /// <summary>
    /// Defines methods for creating objects of the Attack class.
    /// </summary>
    public interface IAttackFactory
    {
        IAttack ManufactureAttack(string name);
    }
}
