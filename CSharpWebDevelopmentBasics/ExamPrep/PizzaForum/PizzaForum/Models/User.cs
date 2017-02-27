namespace PizzaForum.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        public User()
        {
            this.Topics = new HashSet<Topic>();
        }

        public int Id { get; set; }

        [StringLength(450)]
        [MinLength(3)]
        [Index(IsUnique = true)]
        public string Username { get; set; }

        [Index("Email",IsUnique = true)]
        [StringLength(450)]
        public string Email { get; set; }

        [RegularExpression(@"^\d{4}$")]
        [Column(TypeName = "char")]
        [StringLength(4)]
        public string Password { get; set; }

        public bool IsAdmin { get; set; }


        public virtual ICollection<Topic> Topics { get; set; }
        

    }
}
