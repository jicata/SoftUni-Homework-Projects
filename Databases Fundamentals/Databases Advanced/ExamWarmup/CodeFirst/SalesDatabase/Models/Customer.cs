namespace SalesDatabase.Models
{
    using System.Collections.Generic;

    public class Customer
    {

        public Customer()
        {
            this.Sales = new HashSet<Sale>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string CreditCardNumber { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }  


    }
}
