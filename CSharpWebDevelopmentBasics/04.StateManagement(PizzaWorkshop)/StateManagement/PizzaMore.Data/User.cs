using System.Collections.Generic;

namespace PizzaMore.Data
{
    public class User
    {
        public User()
        {
            this.Suggestions = new HashSet<Pizza>();
        }

        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Pizza> Suggestions { get; set; }
    }
}
