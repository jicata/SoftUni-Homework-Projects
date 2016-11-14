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
    }

}