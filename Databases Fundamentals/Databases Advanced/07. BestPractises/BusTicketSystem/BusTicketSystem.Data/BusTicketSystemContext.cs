namespace BusTicketSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;

    public class BusTicketSystemContext : DbContext
    {

        public BusTicketSystemContext()
            : base("name=BusTicketSystemContext")
        {
        }

        public virtual IDbSet<BankAccount> BankAccounts { get; set; }

        public virtual IDbSet<BusCompany> BusCompanies { get; set; }

        public virtual IDbSet<BusStation> BusStations { get; set; }

        public virtual IDbSet<Customer> Customers { get; set; }

        public virtual IDbSet<Review> Reviews { get; set; }

        public virtual IDbSet<Tickets> CustomersTrips { get; set; }

        public virtual IDbSet<Town> Towns { get; set; }

        public virtual IDbSet<Trip> Trips { get; set; }
        
    }

}