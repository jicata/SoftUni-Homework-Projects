using System;
using Empire.Enums;
using Empire.Interfaces;
using Empire.Models;

namespace Empire.Factories
{
    public class ResourceFactory : IResourceFactory
    {
        public IResource CreateResource(ResourceTypes resourceType, int resourceQuantity)
        {
            var resource = new Resource(resourceType, resourceQuantity);
            return resource;
        }

        
    }
}
