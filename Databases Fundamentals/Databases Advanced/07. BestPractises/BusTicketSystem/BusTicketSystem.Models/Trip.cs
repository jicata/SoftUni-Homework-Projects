namespace BusTicketSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using Enum;

    public class Trip
    {
        public Trip()
        {
            this.Tickets = new HashSet<Tickets>();
        }

        public int Id { get; set; }

        public DateTime? DepartureTime { get; set; }

        public DateTime? ArrivalTime { get; set; }

        public Status Status { get; set; }

        [InverseProperty("TripsOriginatingFromTown")]
        public virtual BusStation OriginBusStation { get; set; }

        [InverseProperty("TripsEndingInTown")]
        public virtual BusStation DestinationBusStation { get; set; }

        public virtual BusCompany BusCompany { get; set; }

        public virtual ICollection<Tickets> Tickets { get; set; }
        
        

    }
}

