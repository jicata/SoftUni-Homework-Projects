namespace BankSystem.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SavingsAccount")]
    public class SavingsAccount : BankAccount
    {
        public double InterestRate { get; set; }

        public void AddInterest(double amount)
        {
            this.InterestRate += amount;
        }
    }
}
