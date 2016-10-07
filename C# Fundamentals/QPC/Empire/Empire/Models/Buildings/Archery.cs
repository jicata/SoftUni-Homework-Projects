using System;
using Empire.Enums;
using Empire.Interfaces;


namespace Empire.Models
{
    public class Archery : Building
    {
        private const string unitType = "Archer";
        private const int unitCycle = 3;

        private const ResourceTypes resourceType = ResourceTypes.Gold;
        private const int resourceCycle = 2;
        private const int resourceQuantity = 5;

        public Archery(IResourceFactory resourceFactory, IUnitFactory unitFactory) 
            : base(unitType, resourceType, unitCycle, resourceCycle, resourceQuantity, resourceFactory, unitFactory)
        {

        }
    }
}
