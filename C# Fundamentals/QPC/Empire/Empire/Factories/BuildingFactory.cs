using System;

using Empire.Interfaces;
using Empire.Models;

namespace Empire.Factories
{
    public class BuildingFactory : IBuildingFactory
    {
        public IBuilding CreateBuilding(string buildingType, IUnitFactory unitFactory, IResourceFactory resourceFactory)
        {
            switch (buildingType)
            {
                case "barracks":
                    return new Barracks(resourceFactory, unitFactory);
                case "archery":
                    return  new Archery(resourceFactory, unitFactory);
                default:
                    throw  new ArgumentException("Unknown building type");
            }
        }
    }
}
