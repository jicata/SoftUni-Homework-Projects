namespace BusTicketSystem.Models
{
    using System.Collections.Generic;

    public class Town
    {
        public Town()
        {
            this.BusStations = new HashSet<BusStation>();
            this.Residents = new HashSet<Customer>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public virtual ICollection<BusStation> BusStations { get; set; }

        public virtual ICollection<Customer> Residents { get; set; }
        
        
    }
}
