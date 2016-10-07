using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfKurtovoKonare
{
    class LoanAccount : BankAccount
    {
        public LoanAccount(string customer, decimal balance, double interestRate)
            :base(customer, balance, interestRate)
        {

        }
        public override decimal CalculateInterest(int months)
        {
            if (this.customer.ToLower() == "individual")
            {
                if (months <=3)
                {
                    return this.balance;
                }
                else
                {
                    decimal interest = base.CalculateInterest(months -3);
                    return interest;
                }

            }
            else
            {
                if (months <= 2)
                {

                    return this.balance;
                }
                else
                {
                    decimal interest = base.CalculateInterest(months - 2);
                    return interest;
                }

            }
        }
    }
}
