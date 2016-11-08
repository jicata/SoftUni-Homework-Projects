namespace ProductsShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        public User()
        {
            this.ProductsSold = new HashSet<Product>();
            this.ProductsBought = new HashSet<Product>();
            this.Friends = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        public string LastName { get; set; }

        public int Age { get; set; }    

        [NotMapped]
        public string FullName { get { return this.FirstName + " " + this.LastName; } }

        public virtual ICollection<Product> ProductsSold { get; set; }

        public virtual ICollection<Product> ProductsBought { get; set; }

        public virtual ICollection<User> Friends { get; set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} {this.Age}";
        }
    }
}
