namespace ACTester.Interfaces
{
    public interface IRepository<T> where T : IManufacturable, IModelable
    {
        int Count { get; }

        void Add(T item);

        T GetItem(string manufacturer, string model);
    }
}
