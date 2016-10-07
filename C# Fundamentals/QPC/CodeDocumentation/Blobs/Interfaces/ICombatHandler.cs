using System;


namespace Blobs.Interfaces
{
    /// <summary>
    /// Exposes methods for handling combat interactions between different instances of the Blob class.
    /// </summary>
    public interface ICombatHandler
    {
        IAttack ProduceAttack(IBlob blob);
        void PerformAttack(IBlob blob, IBlob target);
        void RespondToAttack(IBlob blob, IAttack attack);
    }
}
