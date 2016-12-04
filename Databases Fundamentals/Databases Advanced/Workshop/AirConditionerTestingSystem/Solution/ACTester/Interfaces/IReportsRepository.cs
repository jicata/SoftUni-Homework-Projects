namespace ACTester.Interfaces
{
    using System.Collections.Generic;

    public interface IReportsRepository : IRepository<IReport>
    {
        IList<IReport> GetReportsByManufacturer(string manufacturer);
    }
}
