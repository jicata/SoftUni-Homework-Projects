using System;


namespace Blobs.Interfaces
{
    /// <summary>
    /// Exposes methods related to updating an instance of the Behaviour class.
    /// </summary>
    public interface IUpdateable
    {
        bool IsUpdated { get; set; }
        void UpdateBehaviour();
    }
}
