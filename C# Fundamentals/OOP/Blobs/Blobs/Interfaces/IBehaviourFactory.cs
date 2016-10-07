using System;


namespace Blobs.Interfaces
{
    /// <summary>
    /// Defines Behaviour creating methods.
    /// </summary>
    public interface IBehaviourFactory
    {
        IBehaviour CreateBehaviour(string name);
    }
}
