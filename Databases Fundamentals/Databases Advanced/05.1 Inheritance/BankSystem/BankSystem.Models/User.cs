namespace BankSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class User
    {
        private string password;

        public User()
        {
            this.BankAccounts = new HashSet<BankAccount>();
        }
        public int Id { get; set; }

        [RegularExpression(@"^[a-zA-Z][a-zA-Z\d]{2,}")]
        public string Username { get; set; }

        public string Password
        {
            get { return this.password; }

            set
            {
                if (!value.Any(Char.IsLower) || !value.Any(Char.IsUpper) || !value.Any(Char.IsDigit))
                {
                    throw new ArgumentException("Invalid password");
                }
                this.password = value;
            }
        }

        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$")]
        public string Email { get; set; }

        public virtual ICollection<BankAccount> BankAccounts { get; set; }
        
    }
}
