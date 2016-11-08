namespace ProductShop.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using ProductsShop.Models;

    public class ProductsShopContext : DbContext
    {

        public ProductsShopContext()
            : base("name=ProductsShopContext")
        {
        }

        public IDbSet<User> Users { get; set; }
        public IDbSet<Product> Products { get; set; }
        public IDbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany<User>(u=>u.Friends).WithMany()
                .Map(
                    x =>
                    {
                        x.MapLeftKey("UserId");
                        x.MapRightKey("FriendId");
                        x.ToTable("Friends");
                    });
            base.OnModelCreating(modelBuilder);
        }
    }
}
