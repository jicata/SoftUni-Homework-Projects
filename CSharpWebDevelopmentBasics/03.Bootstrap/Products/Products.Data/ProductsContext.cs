namespace Products.Data
{
    using System.Data.Entity;
    using Models;

    public class ProductsContext : DbContext
    {

        public ProductsContext()
            : base("name=ProductsContext")
        {
        }

        public IDbSet<Order> Orders { get; set; }

        public IDbSet<Status> Statuses { get; set; }
    }

}