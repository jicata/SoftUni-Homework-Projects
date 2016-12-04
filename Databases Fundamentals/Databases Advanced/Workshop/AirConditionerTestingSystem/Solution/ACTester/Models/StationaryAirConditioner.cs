namespace ACTester.Models
{
    using System;
    using System.Text;
    using ACTester.Enumerations;
    using ACTester.Utilities;

    public class StationaryAirConditioner : AirConditioner
    {
        private int powerUsage;

        public StationaryAirConditioner(string manufacturer, string model, EnergyEfficiencyRating rating, int powerUsage)
            : base(manufacturer, model)
        {
            this.RequiredEnergyEfficiencyRating = rating;
            this.PowerUsage = powerUsage;
        }

        public EnergyEfficiencyRating RequiredEnergyEfficiencyRating { get; set; }

        public int PowerUsage
        {
            get
            {
                return this.powerUsage;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(Constants.NonPositiveNumber, "Power Usage"));
                }

                this.powerUsage = value;
            }
        }

        public override bool Test()
        {
            if (this.PowerUsage <= (int)this.RequiredEnergyEfficiencyRating || this.RequiredEnergyEfficiencyRating == EnergyEfficiencyRating.E)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            StringBuilder print = new StringBuilder(base.ToString());
            print.AppendLine(string.Format("Required energy efficiency rating: {0}", this.RequiredEnergyEfficiencyRating));
            print.AppendLine(string.Format("Power Usage(KW / h): {0}", this.PowerUsage));
            print.Append("====================");
            return print.ToString();
        }
    }
}
