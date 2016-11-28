namespace BusTicketSystem.Models
{
    using System.Collections.Generic;

    public class BusStation
    {
        public BusStation()
        {
            this.TripsOriginatingFromTown = new HashSet<Trip>();
            this.TripsEndingInTown = new HashSet<Trip>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Town Town { get; set; }

        public virtual ICollection<Trip> TripsOriginatingFromTown { get; set; }

        public virtual ICollection<Trip> TripsEndingInTown { get; set; }
        
        
    }
}
