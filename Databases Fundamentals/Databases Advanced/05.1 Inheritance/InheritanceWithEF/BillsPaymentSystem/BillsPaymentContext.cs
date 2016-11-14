namespace BillsPaymentSystem
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;

    public class BillsPaymentContext : DbContext
    {

        public BillsPaymentContext()
            : base("name=BillsPaymentContext")
        {
        }


        public IDbSet<User> Users { get; set; }

        public IDbSet<BillingDetail> BillingDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankAccount>().Map(b =>
            {
                b.MapInheritedProperties();
                b.ToTable("BankAccount");
            });

            modelBuilder.Entity<CreditCard>().Map(c =>
            {
                c.MapInheritedProperties();
                c.ToTable("CreditCard");
            });
            base.OnModelCreating(modelBuilder);
        }
    }

}