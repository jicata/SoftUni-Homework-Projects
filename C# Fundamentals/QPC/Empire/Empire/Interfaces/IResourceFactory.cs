using System;
using Empire.Enums;

namespace Empire.Interfaces
{
    public interface IResourceFactory
    {
        IResource CreateResource(ResourceTypes resourceType, int resourceQuantity);
    }
}
