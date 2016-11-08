namespace ProductsShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Threading;

    public class Category
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
