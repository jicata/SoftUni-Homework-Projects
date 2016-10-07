using System;


namespace Empire.Interfaces
{
    public  interface IResourceScheduledProducer : IResourceCycle
    {
        bool CanProduceResourse { get; }
    }
}
