namespace BankSystem.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CheckingAccount")]
    public class CheckingAccount : BankAccount
    {
        public double Fee { get; set; }

        public void DeductFee(double amount)
        {
            this.Fee -= amount;
        }
    }
}
