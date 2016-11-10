namespace _02.CreateUser
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    public class User
    {
        private string password;
        private string email;

        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Username { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(6)]
        public string Password
        {
            get { return this.password; }
            set
            {
                string passPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,50}$";
                Regex rgx = new Regex(passPattern);
                if (rgx.IsMatch(value))
                {
                    this.password = value;
                }
                else
                {
                    throw new ArgumentException("Password must contain at least one of the following: lowercase letter, uppercase letter, digit, special symbol");
                }
              
            }
        }

        [Required]
        public string Email
        {
            get { return this.email; }
            set
            {
                string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
                Regex rgx  = new Regex(emailPattern);
                if (rgx.IsMatch(value))
                {
                    this.email = value;
                }
                else
                {
                    throw  new ArgumentException("Invalid e-mail address");
                }
            }
        }

        [MaxLength(1024)]
        public byte[] Picture { get; set; }

        public DateTime? RegisteredOn { get; set; }

        public DateTime? LastTimeLoggedIn { get; set; }

        [Range(1,120)]
        public int Age { get; set; }

        public bool IsDeleted { get; set; }        
              
    }
}
