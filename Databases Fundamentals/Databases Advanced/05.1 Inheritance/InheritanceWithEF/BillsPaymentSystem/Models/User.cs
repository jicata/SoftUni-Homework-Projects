namespace BillsPaymentSystem.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int BillingDetailId { get; set; }

        public virtual BillingDetail BillingDetail { get; set; }
    }
}
