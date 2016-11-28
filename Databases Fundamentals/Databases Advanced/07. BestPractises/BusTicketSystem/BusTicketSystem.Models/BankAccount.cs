namespace BusTicketSystem.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class BankAccount
    {
        [Key]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public string AccountNumber { get; set; }

        public decimal Balance { get; set; }

        public virtual Customer Customer { get; set; }
        
    }
}
