using System;

using Empire.Interfaces;
using Empire.Models;
using Empire.Models.Units;

namespace Empire.Factories
{
    public class UnitFactory : IUnitFactory
    {
        
        public IUnit CreateUnit(string unitType)
        {
            switch (unitType)
            {
                case "Archer":
                    return new Archer();
                case "Swordsman":
                    return  new Swordsman();
                default:
                    throw  new ArgumentException("No such unit");
            }
        }
    }
}
