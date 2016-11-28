namespace BusTicketSystem.Models.Repositories.Base
{
    using Contracts;
    using Data;

    public class BusTicketSystemData : IUnitOfWork
    {
        BusTicketSystemContext context = new BusTicketSystemContext();

        public BusTicketSystemData()
        {
            this.BankAccounts = new Repository<BankAccount>(this.context);
            this.BusCompany = new Repository<BusCompany>(this.context);
            this.BusStations = new Repository<BusStation>(this.context);
            this.Customers = new Repository<Customer>(this.context);
            this.Reviews = new Repository<Review>(this.context);
            this.CustomersTrips = new Repository<Tickets>(this.context);
            this.Towns = new Repository<Town>(this.context);
            this.Trips = new Repository<Trip>(this.context);
        }

        public virtual IRepository<BankAccount> BankAccounts { get; private set; }

        public virtual IRepository<BusCompany> BusCompany { get; private set; }

        public virtual IRepository<BusStation> BusStations { get; private set; }

        public virtual IRepository<Customer> Customers { get; private set; }

        public virtual IRepository<Review> Reviews { get; private set; }

        public virtual IRepository<Tickets> CustomersTrips { get; private set; }

        public virtual IRepository<Town> Towns { get; private set; }

        public virtual IRepository<Trip> Trips { get; private set; }


        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
