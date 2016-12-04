namespace ACTester.Models
{
    using System;
    using System.Text;
    using ACTester.Utilities;

    public class CarAirConditioner : VehicleAirConditioner
    {
        public CarAirConditioner(string manufacturer, string model, int volumeCoverage) : base(manufacturer, model, volumeCoverage)
        {
        }

        public override bool Test()
        {
            double sqrtVolume = Math.Sqrt(this.VolumeCovered);
            if (sqrtVolume < Constants.MinCarVolume)
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder print = new StringBuilder(base.ToString());
            print.Append("====================");
            return print.ToString();
        }
    }
}
