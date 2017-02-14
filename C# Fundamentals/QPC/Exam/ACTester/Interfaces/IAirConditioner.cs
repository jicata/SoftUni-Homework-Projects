namespace ACTester.Interfaces
{
    /// <summary>
    /// An interface representing the abstract class that carries information common for all air conditioners.
    /// </summary>
    public interface IAirConditioner : IManufacturable, IModelable
    {
        /// <summary>
        /// A method that tests if an Air Conditioner meets the requierments for a passing mark.
        /// </summary>
        /// <returns>Returns a boolean value specifying if the test was sucessfull, true for a passing mark and false for a failing one.</returns>
        bool Test();
    }
}
