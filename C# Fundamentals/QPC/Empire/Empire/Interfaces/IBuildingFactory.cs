using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empire.Interfaces
{
    public interface IBuildingFactory
    {
        IBuilding CreateBuilding(string BuildingType, IUnitFactory unitFactory, IResourceFactory resourceFactory);
    }
}
