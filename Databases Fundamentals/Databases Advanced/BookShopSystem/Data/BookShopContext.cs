namespace Data
{
    using System.Data.Entity;
    using Models;

    public class BookShopContext : DbContext
    {
        
        public BookShopContext()
            : base("name=BookShopContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasMany(b=>b.RelatedBooks).WithMany().Map(m =>
            {
                m.MapLeftKey("BookId");
                m.MapRightKey("RelatedId");
                m.ToTable("RelatedBooks");
            });
            base.OnModelCreating(modelBuilder);
        }

        public IDbSet<Book> Books { get; set; }
        public IDbSet<Author> Authors { get; set; }
        public IDbSet<Category> Categories { get; set; }
              
    }
}