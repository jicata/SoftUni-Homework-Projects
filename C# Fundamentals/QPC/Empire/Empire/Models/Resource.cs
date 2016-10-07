using System;
using Empire.Enums;
using Empire.Interfaces;


namespace Empire.Models
{
    public class Resource : IResource
    {
        private int resourceQuantity;

        public Resource(ResourceTypes resourceType, int resourceQuantity)
        {
            this.ResourceType = resourceType;
            this.resourceQuantity = resourceQuantity;
        }

        public ResourceTypes ResourceType { get; set; }

        public int ResourceQuantity
        {
            get { return this.resourceQuantity; }
            set { this.resourceQuantity = value; }

        }
    }
}
