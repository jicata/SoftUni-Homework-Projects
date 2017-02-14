namespace ACTester.Models
{
    using System;
    using System.Text;
    using ACTester.Utilities;

    public class PlaneAirConditioner : VehicleAirConditioner
    {
        private int electricityUsed;

        public PlaneAirConditioner(string manufacturer, string model, int volumeCoverage, int electricityUsed) : base(manufacturer, model, volumeCoverage)
        {
            this.ElectricityUsed = electricityUsed;
        }

        public int ElectricityUsed
        {
            get
            {
                return this.electricityUsed;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(Constants.NonPositiveNumber, "Electricity Used"));
                }

                this.electricityUsed = value;
            }
        }

        public override bool Test()
        {
            double sqrtVolume = Math.Sqrt(this.VolumeCovered);
            if ((this.ElectricityUsed / sqrtVolume) < Constants.MinPlaneElectricity)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            StringBuilder print = new StringBuilder(base.ToString());
            print.AppendLine(string.Format("Electricity Used: {0}", this.ElectricityUsed));
            print.Append("====================");
            return print.ToString();
        }
    }
}
