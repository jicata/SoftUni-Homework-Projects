namespace BillsPaymentSystem.Models
{
    using System.ComponentModel.DataAnnotations.Schema;


    public class BankAccount : BillingDetail
    {

        public string BankName { get; set; }

        public string Swift { get; set; }
    }
}
