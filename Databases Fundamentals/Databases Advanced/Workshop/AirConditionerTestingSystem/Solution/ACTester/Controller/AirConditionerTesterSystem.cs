namespace ACTester.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ACTester.Database;
    using ACTester.Enumerations;
    using ACTester.Interfaces;
    using ACTester.Models;
    using ACTester.Utilities;

    public class AirConditionerTesterSystem : IAirConditionerTesterSystem
    {
        public AirConditionerTesterSystem(IAirConditionerTesterDatabase database)
        {
            this.Database = database;
        }

        public AirConditionerTesterSystem() : this(new AirConditionerTesterDatabase())
        {
        }

        public IAirConditionerTesterDatabase Database { get; private set; }

        public string RegisterStationaryAirConditioner(string manufacturer, string model, string energyEfficiencyRating, int powerUsage)
        {
            EnergyEfficiencyRating rating;
            try
            {
                rating =
                    (EnergyEfficiencyRating)Enum.Parse(typeof(EnergyEfficiencyRating), energyEfficiencyRating);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(Constants.IncorrectEnergyEfficiencyRating, ex);
            }

            IAirConditioner airConditioner = new StationaryAirConditioner(manufacturer, model, rating, powerUsage);
            this.Database.AirConditioners.Add(airConditioner);
            return string.Format(Constants.RegisterAirConditioner, airConditioner.Model, airConditioner.Manufacturer);
        }

        public string RegisterCarAirConditioner(string manufacturer, string model, int volumeCoverage)
        {
            IAirConditioner airConditioner = new CarAirConditioner(manufacturer, model, volumeCoverage);
            this.Database.AirConditioners.Add(airConditioner);
            return string.Format(Constants.RegisterAirConditioner, airConditioner.Model, airConditioner.Manufacturer);
        }

        /// <summary>
        /// A method that registers a new PlaneAirConditioner in the database from a given manufacturer, model and volume coverage and electricity used if they pass validation.
        /// </summary>
        /// <param name="manufacturer">The Manufacturer of the air conditioner.</param>
        /// <param name="model">The model of the air conditioner.</param>
        /// <param name="volumeCoverage">An integer value specifying the volume coverage of the air conditioner.</param>
        /// <param name="electricityUsed">An integer value specifying the electricity used of the air conditioner.</param>
        /// <returns>If the input values pass validation the method returns a string with a success message, otherwise it throws an appropriate exception.</returns>
        public string RegisterPlaneAirConditioner(string manufacturer, string model, int volumeCoverage, int electricityUsed)
        {
            IAirConditioner airConditioner = new PlaneAirConditioner(manufacturer, model, volumeCoverage, electricityUsed);
            this.Database.AirConditioners.Add(airConditioner);
            return string.Format(Constants.RegisterAirConditioner, airConditioner.Model, airConditioner.Manufacturer);
        }

        public string TestAirConditioner(string manufacturer, string model)
        {
            IAirConditioner airConditioner = this.Database.AirConditioners.GetItem(manufacturer, model);
            var mark = airConditioner.Test() ? Mark.Passed : Mark.Failed;
            this.Database.Reports.Add(new Report(airConditioner.Manufacturer, airConditioner.Model, mark));
            return string.Format(Constants.TestAirConditioner, model, manufacturer);
        }

        /// <summary>
        /// A method that finds an Air Conditioner in the database from a given manufacturer and model.
        /// </summary>
        /// <param name="manufacturer">The Manufacturer of the searched air conditioner.</param>
        /// <param name="model">The model of the searched air conditioner.</param>
        /// <returns>If the air conditioner exists in the database returns it's string represention, othrerwise it throws an appropriate exception.</returns>
        public string FindAirConditioner(string manufacturer, string model)
        {
            IAirConditioner airConditioner = this.Database.AirConditioners.GetItem(manufacturer, model);
            return airConditioner.ToString();
        }

        public string FindReport(string manufacturer, string model)
        {
            IReport report = this.Database.Reports.GetItem(manufacturer, model);
            return report.ToString();
        }

        public string FindAllReportsByManufacturer(string manufacturer)
        {
            IList<IReport> reports = this.Database.Reports.GetReportsByManufacturer(manufacturer);
            if (reports.Count == 0)
            {
                return Constants.NoReports;
            }

            reports = reports.OrderBy(x => x.Model).ToList();
            StringBuilder reportsPrint = new StringBuilder();
            reportsPrint.AppendLine(string.Format("Reports from {0}:", manufacturer));
            reportsPrint.Append(string.Join(Environment.NewLine, reports));
            return reportsPrint.ToString();
        }

        /// <summary>
        /// A method which displays the system status as a percentage representing the number of tested air conditioners.
        /// </summary>
        /// <returns>Returns a string displaying the percentage of tested air conditioners.</returns>
        public string Status()
        {
            int reports = this.Database.Reports.Count;
            double airConditioners = this.Database.AirConditioners.Count;
            if (reports == 0)
            {
                return string.Format(Constants.Status, 0);
            }

            double percent = reports / airConditioners;
            percent = percent * 100;
            return string.Format(Constants.Status, percent);
        }
    }
}
