using System;
using Empire.Enums;

namespace Empire.Interfaces
{
    public interface IResource
    {
        ResourceTypes ResourceType { get; }
        int ResourceQuantity { get; }
    }
}
