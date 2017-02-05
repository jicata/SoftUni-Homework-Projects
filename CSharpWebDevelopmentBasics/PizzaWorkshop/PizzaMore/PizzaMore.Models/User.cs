namespace PizzaMore.Models
{
    using System.Collections.Generic;

    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Pizza> Suggestions { get; set; }
        
    }
}
