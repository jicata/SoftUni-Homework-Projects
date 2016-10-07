using System;

namespace Blobs.Interfaces
{
    /// <summary>
    /// Defines properties and methods for the Attack class.
    /// </summary>
    public interface IAttack
    {
        int Damage { get; set; }
        IAttack CreateAttack(IBlob blob);
        IAttack ModifyAttack(IAttack attack, IBlob blob);
    }
}
