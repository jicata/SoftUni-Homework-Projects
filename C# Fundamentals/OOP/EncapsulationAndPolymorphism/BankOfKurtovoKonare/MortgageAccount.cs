using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfKurtovoKonare
{
    class MortgageAccount : BankAccount
    {
        public MortgageAccount(string customer, decimal balance, double interestRate)
            : base(customer, balance, interestRate)
        {

        }
        public override decimal CalculateInterest(int months)
        {
            if (this.customer.ToLower() == "company")
            {
                if (months <= 12)
                {
                    decimal interest = base.CalculateInterest(months);
                    return interest /2;
                }
                else
                {
                    decimal interest = base.CalculateInterest(12);
                    decimal moreInterest = base.CalculateInterest(months - 12);
                    return interest/2 + moreInterest;
                }
                
            }
            else
            {
                if (months <=6)
                {

                    return this.balance;
                }
                else
                {
                    decimal interest = base.CalculateInterest(months - 6);
                    return interest;
                }
                
            }
        }
    }
}
