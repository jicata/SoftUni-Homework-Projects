namespace BusTicketSystem.Models
{
    using System.Collections.Generic;

    public class BusCompany
    {
        public BusCompany()
        {
            this.Reviews = new HashSet<Review>();
            this.Trips = new HashSet<Trip>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Nationality { get; set; }

        public float Rating { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Trip> Trips { get; set; }
        
    }
}
