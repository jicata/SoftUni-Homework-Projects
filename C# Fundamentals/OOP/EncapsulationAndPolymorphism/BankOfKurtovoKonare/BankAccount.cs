
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfKurtovoKonare
{
    public abstract class BankAccount : IInterestCalculable, IDepositable
    {
        protected string customer;
        protected decimal balance;
        protected double interestRate;

        public BankAccount(string customer, decimal balance, double interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        protected string Customer
        {
            get { return customer; }
            set {
                if (value.ToLower() != "individual" && value.ToLower() != "company")
                {
                    throw new ArgumentException("Customers can be only \"individual\" or \"company\"");
                }
                customer = value; }
        }
        protected decimal Balance
        {
            get { return balance; }
            set {
                if (value < 0)
                {
                    throw new ArgumentException("Balance cannot be negative");
                }
                balance = value; }
        }
        protected virtual double InterestRate
        {
            get { return interestRate; }
            set {
                if (value < 0)
                {
                    throw new ArgumentException("Interest rate cannot be negative");
                }
                interestRate = value; }
        }

        public virtual decimal CalculateInterest(int months)
        {
            if (this.InterestRate > 0)
            {
                decimal calculatedInterest = this.balance * (1 + (decimal)this.interestRate/100 * (decimal)months);
                return calculatedInterest;
            }
            else
            {
                return this.balance;
            }
            
           
        }

        public void DepositMoney(decimal money)
        {
            this.balance += money;
        }

    }
}
