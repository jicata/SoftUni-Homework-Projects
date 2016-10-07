using System;
using Blobs.Interfaces;


namespace Blobs.Models
{
    public abstract class Behaviour : IBehaviour
    {
        public bool IsTriggered { get; set; }
        public abstract void Trigger(IBlob blob);
        public abstract void Apply(IBlob blob);
       
    }
}
