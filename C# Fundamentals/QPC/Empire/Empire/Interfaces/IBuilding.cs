using System;
using System.Security.Cryptography.X509Certificates;
using Empire.Enums;
using Empire.Factories;

namespace Empire.Interfaces
{
    public interface IBuilding: IResourceScheduledProducer, IUnitScheduledProducer, IUpdateable
    {
        IResource ProduceResource();
        IUnit ProduceUnit();
        int ResourceQuantity { get; }
        ResourceTypes ResourceType { get; }
        string ToString();

    }
}
