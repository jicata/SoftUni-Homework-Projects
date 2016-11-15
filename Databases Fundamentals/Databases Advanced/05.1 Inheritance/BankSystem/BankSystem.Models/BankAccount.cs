namespace BankSystem.Models
{
    public abstract class BankAccount
    {
        public int Id { get; set; }

        public string AccountNumber { get; set; }

        public decimal Balance { get; set; }

        public void DepositMoney(decimal amount)
        {
            this.Balance += amount;
        }

        public void WithdrawMoney(decimal amount)
        {
            this.Balance -= amount;
        }
    }
}
