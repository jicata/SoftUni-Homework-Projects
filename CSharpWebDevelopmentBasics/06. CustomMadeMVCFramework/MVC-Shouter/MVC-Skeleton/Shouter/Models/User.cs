namespace Shouter.Models
{
    using System;

    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public DateTime? Birthdate { get; set; }
    }
}
