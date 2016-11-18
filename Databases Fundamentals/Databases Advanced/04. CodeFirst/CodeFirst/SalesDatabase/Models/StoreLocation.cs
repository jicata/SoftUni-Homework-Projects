namespace SalesDatabase.Models
{
    using System.Collections.Generic;

    public class StoreLocation
    {
        public StoreLocation()
        {
            this.Sales = new HashSet<Sale>();
        }

        public int Id { get; set; }

        public string LocationName { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
