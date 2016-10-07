using System;

using Empire.Engine;
using Empire.Factories;

namespace Empire
{
    class Program
    {
        static void Main()
        {
            InputReader inputReader = new InputReader();
            OutputWriter outputWriter = new OutputWriter();
            UnitFactory uf = new UnitFactory();
            ResourceFactory rf = new ResourceFactory();
            BuildingFactory bf = new BuildingFactory();
            EmpireDatabase database = new EmpireDatabase();
            Engine.Engine engine = new Engine.Engine(outputWriter, inputReader, rf, uf, bf, database);
            engine.Run();

            
        }
    }
}
