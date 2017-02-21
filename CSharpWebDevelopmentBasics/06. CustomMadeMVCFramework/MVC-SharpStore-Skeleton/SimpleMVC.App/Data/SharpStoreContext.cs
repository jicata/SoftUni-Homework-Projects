namespace SharpStore.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Models;

    public partial class SharpStoreContext : DbContext
    {
        public SharpStoreContext()
            : base("name=SharpStore")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Knife> Knives { get; set; }
        public virtual DbSet<Message> Messages { get; set; }

        public virtual DbSet<Buyer> Buyers { get; set; }

        public virtual DbSet<User> Users { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
