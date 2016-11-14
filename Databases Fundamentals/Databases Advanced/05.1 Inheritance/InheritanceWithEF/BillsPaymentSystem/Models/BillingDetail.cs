namespace BillsPaymentSystem.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;

    public abstract class BillingDetail
    {
        public int Id { get; set; }

        public int Number { get; set; }

        [ForeignKey("Owner")]
        public int UserId { get; set; }
        
        public User Owner { get; set; }
    }
}
