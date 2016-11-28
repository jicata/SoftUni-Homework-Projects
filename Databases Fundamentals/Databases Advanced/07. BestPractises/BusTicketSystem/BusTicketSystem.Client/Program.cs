namespace BusTicketSystem.Client
{
    using System.Linq;
    using Models.Repositories.Base;

    class Program
    {
        static void Main(string[] args)
        {
            BusTicketSystemData data = new BusTicketSystemData();
            data.BusCompany.Get().Count();
        }
    }
}
