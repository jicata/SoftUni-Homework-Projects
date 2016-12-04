namespace ACTester.Interfaces
{
    public interface IAirConditionerTesterDatabase
    {
        IRepository<IAirConditioner> AirConditioners { get; }

        IReportsRepository Reports { get; }
    }
}
