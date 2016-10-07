using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empire.Enums;
using Empire.Interfaces;

namespace Empire.Engine
{
    class EmpireDatabase : IDatabase
    {
        private ICollection<IBuilding> buildings = new List<IBuilding>();
        

        public EmpireDatabase()
        {
           InitTreasury();
            this.Units = new Dictionary<string, int>();
        }

        public ICollection<IBuilding> Buildings { get; } = new List<IBuilding>();
        public IDictionary<string, int> Units { get; }
        public IDictionary<ResourceTypes, int> Treasury { get; set; }
        public void InitTreasury()
        {
            this.Treasury = new Dictionary<ResourceTypes, int>();
            this.Treasury.Add(ResourceTypes.Gold,0);
            this.Treasury.Add(ResourceTypes.Steel,0);
        }

        public void AddUnit(IUnit unit)
        {
            string unitType = unit.GetType().Name;
            if (this.Units.ContainsKey(unitType))
            {
                this.Units[unitType] += 1;
            }
            else
            {
                this.Units.Add(unitType, 1);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Treasury:");
            sb.Append("\n--Gold: " + this.Treasury[ResourceTypes.Gold]);
            sb.Append("\n--Steel: " + this.Treasury[ResourceTypes.Steel]);
            sb.Append("\nBuildings: \n");
            if(this.Buildings.Any())
            foreach (IBuilding building in this.Buildings)
            {
                sb.Append(building.ToString());
            }
            else
            {
                sb.Append("\nN/A");
            }
            sb.Append("Units: ");
            if (this.Units.Any())
            {
                foreach (var unit in this.Units)
                {
                    sb.Append("\n--"+unit.Key + ": " + unit.Value);
                }
            }
            else
            {
                sb.Append("\nN/A");
            }
            return sb.ToString();
        }
    }
}
