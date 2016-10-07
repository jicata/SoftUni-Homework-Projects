using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Empire.Factories;
using Empire.Interfaces;

namespace Empire.Engine
{
    public class Engine : IEngine
    {
        private IOutputWriter writer = new OutputWriter();
        private IInputReader reader = new InputReader();
        private IResourceFactory resourceFactory = new ResourceFactory();
        private IUnitFactory unitFactory = new UnitFactory();
        private IBuildingFactory buildingFactory = new BuildingFactory();
        private IDatabase database = new EmpireDatabase();

        public Engine(IOutputWriter writer, IInputReader reader, IResourceFactory resourceFactory, IUnitFactory unitFactory, IBuildingFactory buildingFactory, IDatabase database)
        {


        }

        
        public void Run()
        {
            while (true)
            {
               
                ExecuteCommand(reader.ReadLine());
                foreach (IBuilding building in database.Buildings)
                {
                    building.Update();
                }
                foreach (IBuilding building in database.Buildings)
                {
                    if (building.CanProduceResourse)
                    {
                        IResource resource = building.ProduceResource();
                        this.database.Treasury[resource.ResourceType] += resource.ResourceQuantity;
                    }
                    if (building.CanProduceUnit)
                    {
                        IUnit unit = building.ProduceUnit();
                        this.database.AddUnit(unit);

                    }
                }
            }

            
        }

       

        public IOutputWriter Writer
        {
            get
            {
                return writer;
            }

            set
            {
                writer = value;
            }
        }
        public IInputReader Reader
        {
            get
            {
                return reader;
            }

            set
            {
                reader = value;
            }
        }

        private void ExecuteCommand(string command)
        {
            string[] CommandArgs = command.Split();

            switch (CommandArgs[0])
            {
                case "build":
                    this.database.Buildings.Add(ExecuteBuildCommand(CommandArgs));
                    break;
                case "empire-status":
                    this.writer.Print(ExecuteStatusCommand(CommandArgs));
                    break;
                case "skip":
                    break;
                case "armistice":
                    ExecuteFinalCommand();
                    break;
                default:
                    throw  new ArgumentException("Unrecognized command");
            }
        }

        private IBuilding ExecuteBuildCommand(string[] commandArgs)
        {
            switch (commandArgs[1])
            {
                case "barracks":
                    return this.buildingFactory.CreateBuilding(commandArgs[1], this.unitFactory, this.resourceFactory);
                case "archery":
                    return this.buildingFactory.CreateBuilding(commandArgs[1], this.unitFactory, this.resourceFactory);
                default:
                    throw  new ArgumentException("Unrecognised building type");
            }
        }

        private string ExecuteStatusCommand(string[] commandArgs)
        {
            return this.database.ToString();
        }

       
        private void ExecuteFinalCommand()
        {
            Environment.Exit(0);
        }

    }
}
