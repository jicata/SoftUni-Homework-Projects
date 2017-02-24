namespace Shouter.Models
{
    using System;
    using System.Collections.Generic;

    public class User
    {
        public User()
        {
            this.Following = new List<User>();
        }
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public DateTime? Birthdate { get; set; }

        public virtual ICollection<User> Following { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }
        
        
        
    }
}
