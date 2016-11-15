namespace BankSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;

    public class BankSystemContext : DbContext
    {

        public BankSystemContext()
            : base("name=BankSystemContext")
        {
        }

        public IDbSet<BankAccount> BankAccounts { get; set; }

        public IDbSet<User> Users { get; set; }
    }
}