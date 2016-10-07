using System;
using System.Text;
using System.Text.RegularExpressions;
using Empire.Enums;
using Empire.Factories;
using Empire.Interfaces;


namespace Empire.Models
{
    public abstract class Building : IBuilding
    {
        private int turnsPassed = -1;
        private string unitType;
        private int unitCycle;
        private int resourceQuantity;
        private ResourceTypes resourceType;
        private int resourceCycle;
        private IResourceFactory resourceFactory;
        private IUnitFactory unitFactory;
        private bool canProduceResource;
        private bool canProduceUnit;

        public Building(string unitType, ResourceTypes resourceType, int unitCycle, int resourceCycle, int resourceQuantity, IResourceFactory resourceFactory, IUnitFactory unitFactory)
        {
            this.UnitType = unitType;
            this.ResourceType = resourceType;
            this.UnitCycle = unitCycle;
            this.ResourceCycle = resourceCycle;
            this.ResourceQuantity = resourceQuantity;
            this.ResourceFactory = resourceFactory;
            this.UnitFactory = unitFactory;

        }

        public bool CanProduceResourse
        {
            get
            {
                if (turnsPassed > 0 && turnsPassed%this.ResourceCycle == 0)
                {
                    canProduceResource = true;
                }
                else
                {
                    canProduceResource = false;
                }
                return this.canProduceResource;
            }
            
        }

        public bool CanProduceUnit
        {
            get
            {
                if (turnsPassed > 0 && turnsPassed % this.UnitCycle == 0)
                {
                    canProduceUnit = true;
                }
                else
                {
                    canProduceUnit = false;
                }
                return this.canProduceUnit;
            }


        }

        public int ResourceCycle { get; private set; }
        public int UnitCycle { get; private set; }

        public string UnitType
        {
            get
            {
                return unitType;
            }

            set
            {
                unitType = value;
            }
        }

        public ResourceTypes ResourceType
        {
            get
            {
                return resourceType;
            }

            set
            {
                resourceType = value;
            }
        }

        public IResourceFactory ResourceFactory
        {
            get
            {
                return resourceFactory;
            }

            set
            {
                resourceFactory = value;
            }
        }

        public IUnitFactory UnitFactory
        {
            get
            {
                return unitFactory;
            }

            set
            {
                unitFactory = value;
            }
        }

        public int ResourceQuantity
        {
            get
            {
                return resourceQuantity;
            }

            set
            {
                resourceQuantity = value;
            }
        }

        public int TurnsPassed
        {
            get
            {
                return turnsPassed;
            }

            set
            {
                turnsPassed = value;
            }
        }

        

        public IResource ProduceResource()
        {
            
            var resource = this.ResourceFactory.CreateResource(this.ResourceType, this.ResourceQuantity);
            return resource;
        }

        public IUnit ProduceUnit()
        {
            var unit = this.UnitFactory.CreateUnit(this.UnitType);
            return unit;
        }


        public void Update()
        {
            this.TurnsPassed ++;
        }

        public override string ToString()
        {
            int turnsUntilUnit = this.UnitCycle - (turnsPassed%this.UnitCycle);
            int turnsUntilResource = this.ResourceCycle - (turnsPassed%this.ResourceCycle);
            //--Barracks: 1 turns (3 turns until Swordsman, 2 turns until Steel)
            String toPrint = String.Format("--{0}: {1} turns ({2} turns until {3}, {4} turns until {5})\n",
                this.GetType().Name,
                this.turnsPassed,
                turnsUntilUnit,
                this.unitType,
                turnsUntilResource,
                this.ResourceType.ToString());
            return toPrint;

        }
    }
}
