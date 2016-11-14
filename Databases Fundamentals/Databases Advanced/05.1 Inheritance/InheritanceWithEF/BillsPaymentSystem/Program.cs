
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillsPaymentSystem
{
    using System.Diagnostics;
    using Models;

    class Program
    {
        static void Main(string[] args)
        {
            BillsPaymentContext context = new BillsPaymentContext();
            context.Users.Count();

              CreditCard creditCard = new CreditCard()
                {
                    Number = "987654321",
                    CardType = "MasterCard"
                };
                User user = new User()
                {
                    FirstName =  "Gosho",
                    BillingDetail = creditCard
                };
                context.Users.Add(user);
                context.SaveChanges();

            User user2 = context.Users.Find(1);
            CreditCard item = context.BillingDetails.OfType<CreditCard>().First();
            Console.WriteLine(item.CardType);
        }
        
    }
}
