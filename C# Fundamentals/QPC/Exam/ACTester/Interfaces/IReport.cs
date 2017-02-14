namespace ACTester.Interfaces
{
    using ACTester.Enumerations;

    /// <summary>
    /// An interface representing the class that carries information common for all reports.
    /// </summary>
    public interface IReport : IManufacturable, IModelable
    {
        /// <summary>
        /// A mark representing if the associated air conditioner passed or failed it's test.
        /// </summary>
        Mark Mark { get; }
    }
}
