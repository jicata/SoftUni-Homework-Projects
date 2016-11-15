
namespace BankSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<BankSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BankSystemContext context)
        {
            if (context.BankAccounts.Any())
            {
                return;
            }
            BankAccount saveAcc = new SavingsAccount()
            {
                AccountNumber = "123456789",
                Balance = 20.5M,
                InterestRate = 4.2
            };
            BankAccount checkAcc = new CheckingAccount()
            {
                AccountNumber = "987654321",
                Balance = 150M,
                Fee = 5.5
            };

            User user = new User() {Username = "Kalufi", Email = "kur@doma.net", Password = "Aa123bvgs"};
            user.BankAccounts.Add(saveAcc);
            user.BankAccounts.Add(checkAcc);
            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}
