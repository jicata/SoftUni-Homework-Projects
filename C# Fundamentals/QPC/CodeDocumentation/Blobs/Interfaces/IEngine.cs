using System;
using System.Collections.Generic;
using Blobs.Engine;


namespace Blobs.Interfaces
{
    /// <summary>
    /// Exposes different properties and methods used by the Engine class.
    /// </summary>
    public interface IEngine
    {
        ICombatHandler CombatHandler { get; }
        IBlobFactory BlobFactory { get; }
        IBehaviourFactory BehaviourFactory { get; }
        IAttackFactory AttackFactory { get; }
        IInputReader Reader { get; }
        IOutputWriter Writer { get; }
        ICommandExecutor CommandExecutor { get; }
        ICollection<IBlob> Blobs { get; } 
        void Run();
    }
}
