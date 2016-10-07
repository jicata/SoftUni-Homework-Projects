using System;

namespace Empire.Interfaces
{
    public interface IUnitScheduledProducer : IUnitCycle
    {
        bool CanProduceUnit { get; }
    }
}
