using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empire.Enums;

namespace Empire.Interfaces
{
    public interface IDatabase
    {
        ICollection<IBuilding> Buildings { get; }
        IDictionary<string, int> Units { get; } 
        IDictionary<ResourceTypes, int> Treasury {get;}
        void AddUnit(IUnit unit);
        void InitTreasury();
    }
}
