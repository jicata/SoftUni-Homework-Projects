using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfKurtovoKonare
{
    public class DepositAccount : BankAccount, IWithdrawable
    {
        public DepositAccount(string customer, decimal balance, double interestRate)
            : base(customer, balance, interestRate)
        {
            this.InterestRate = interestRate;
        }


        public void WithdrawlMoney(decimal money)
        {
            this.balance -= money;
        }

        public override decimal CalculateInterest(int months)
        {
            if (this.balance > 0 && this.balance < 1000)
            {
                return this.balance;
            }
            else
            {
                decimal calculatedInterest = this.balance * (1 + (decimal)this.interestRate/100 * (decimal)months);
                return calculatedInterest;
            }
        }
       
    }
}
