namespace BillsPaymentSystem.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public abstract class BillingDetail
    {
        [Key, ForeignKey("Owner")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OwnerId { get; set; }

        public string Number { get; set; }

        public virtual User Owner { get; set; }
    }
}
