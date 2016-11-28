namespace BusTicketSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using Models.Enum;
    using Models.Repositories.Base;

    internal sealed class Configuration : DbMigrationsConfiguration<BusTicketSystem.Data.BusTicketSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BusTicketSystem.Data.BusTicketSystemContext context)
        {
            BusTicketSystemData data = new BusTicketSystemData();
            BankAccount ba1 = new BankAccount() { AccountNumber = "12345", Balance = 15 };
            BankAccount ba2 = new BankAccount() { AccountNumber = "54321", Balance = 50 };

            Customer cu1 = new Customer() { FirstName = "Ujasen", LastName = "Ujas" };
            Customer cu2 = new Customer() { FirstName = "Pesho", LastName = "Peshev" };

            Tickets tic1 = new Tickets() { Price = 20, Seat = "12A" };
            Tickets tic2 = new Tickets() { Price = 90, Seat = "4G" };

            BusCompany bc1 = new BusCompany() { Name = "Biomet", Nationality = "Bulgarian" };
            BusCompany bc2 = new BusCompany() { Name = "UnionIvkoni", Nationality = "Mangali" };

            Review r1 = new Review() { Content = "Stava", Grade = 8.0f };
            Review r2 = new Review() { Content = "mamata si djasa", Grade = 2.1f };

            Town t1 = new Town() { Name = "Mramor", Country = "Bulgaria" };
            Town t2 = new Town() { Name = "Prilep", Country = "Makedonija" };

            BusStation bs1 = new BusStation() { Name = "Krai na s. Mramor" };
            BusStation bs2 = new BusStation() { Name = "Centar vo Prilep" };

            Trip tr1 = new Trip()
            {
                ArrivalTime = new DateTime(2016, 11, 29),
                DepartureTime = new DateTime(2016, 11, 28),
                Status = Status.Departed
            };
            Trip tr2 = new Trip()
            {
                ArrivalTime = DateTime.Today,
                DepartureTime = new DateTime(2016, 11, 20),
                Status = Status.Arrived
            };
            cu1.BankAccount = ba1;
            cu2.BankAccount = ba2;

            cu1.HomeTown = t1;
            cu2.HomeTown = t2;
            cu1.Reviews.Add(r1);
            cu2.Reviews.Add(r2);


            t1.BusStations.Add(bs1);
            t2.BusStations.Add(bs2);

            bc1.Reviews.Add(r1);
            bc2.Reviews.Add(r2);

            tr1.OriginBusStation = bs1;
            tr1.DestinationBusStation = bs2;
            tr2.OriginBusStation = bs2;
            tr2.DestinationBusStation = bs1;
            tr1.BusCompany = bc1;
            tr2.BusCompany = bc2;

            tic1.Trip = tr1;
            tic1.Customer = cu1;
            tic2.Trip = tr2;
            tic2.Customer = cu2;

            data.Customers.Add(cu1);
            data.Customers.Add(cu2);
            data.Trips.Add(tr1);
            data.Trips.Add(tr2);
            data.CustomersTrips.Add(tic1);
            data.CustomersTrips.Add(tic2);
            data.Save();

        }
    }
}
