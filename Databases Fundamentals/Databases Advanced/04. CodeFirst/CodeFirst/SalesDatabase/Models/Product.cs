namespace SalesDatabase.Models
{
    using System;
    using System.Collections.Generic;

    public class Product
    {
        public Product()
        {
            this.Sales = new HashSet<Sale>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
