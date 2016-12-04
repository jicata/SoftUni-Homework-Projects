namespace ACTester.Database
{
    using System.Collections.Generic;
    using ACTester.Interfaces;

    public class ReportsRepository : Repository<IReport>, IReportsRepository
    {
        public ReportsRepository()
        {
            this.ItemsByManufacturer = new Dictionary<string, IList<IReport>>();
        }

        protected Dictionary<string, IList<IReport>> ItemsByManufacturer { get; set; }

        public override void Add(IReport item)
        {
            base.Add(item);
            if (!this.ItemsByManufacturer.ContainsKey(item.Manufacturer))
            {
                this.ItemsByManufacturer.Add(item.Manufacturer, new List<IReport>());
            }

            this.ItemsByManufacturer[item.Manufacturer].Add(item);
        }

        public IList<IReport> GetReportsByManufacturer(string manufacturer)
        {
            if (!this.ItemsByManufacturer.ContainsKey(manufacturer))
            {
                return new List<IReport>();
            }

            return new List<IReport>(this.ItemsByManufacturer[manufacturer]);
        }
    }
}
