namespace VehicleSystem
{
    using System.Linq;
    using Data;

    class Program
    {
        static void Main()
        {
            VehicleSystemContext context = new VehicleSystemContext();
            context.Carriages.Count();
        }
    }
}
