namespace BillsPaymentSystem.Models
{
    using System.ComponentModel.DataAnnotations.Schema;   
    public class CreditCard : BillingDetail
    {
        public string CardType { get; set; }

        public int ExpirationMonth { get; set; }

        public int ExpirationYear { get; set; }

    }
}
