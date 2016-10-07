using System;


namespace Empire.Interfaces
{
    public interface IUnitFactory
    {
        IUnit CreateUnit(string unitType);
    }
}
