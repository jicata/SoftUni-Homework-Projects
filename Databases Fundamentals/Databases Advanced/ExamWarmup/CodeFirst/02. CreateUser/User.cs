namespace _02.CreateUser
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        private string password;

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
            set { this.password = value; }
        }

        [Required]
        public string Email { get; set; }

        [MaxLength(1024)]
        public byte[] Picture { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime LastTimeLoggedIn { get; set; }

        [Range(1,120)]
        public int Age { get; set; }

        public bool IsDeleted { get; set; }        
              
    }
}
