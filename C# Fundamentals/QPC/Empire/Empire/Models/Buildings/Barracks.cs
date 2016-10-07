using System;
using Empire.Enums;
using Empire.Interfaces;


namespace Empire.Models
{
    public class Barracks : Building
    {
        private const string unitType = "Swordsman";
        private const int unitCycle = 4;

        private const ResourceTypes resourceType = ResourceTypes.Steel;
        private const int resourceCycle = 3;
        private const int resourceQuantity = 10;

        public Barracks(IResourceFactory resourceFactory, IUnitFactory unitFactory)
            : base(unitType, resourceType, unitCycle, resourceCycle, resourceQuantity, resourceFactory, unitFactory)
        {

        }
    }
}
