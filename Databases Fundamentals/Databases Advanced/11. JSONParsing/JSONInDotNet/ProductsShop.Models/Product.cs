namespace ProductsShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        public Product()
        {
            this.Categories = new HashSet<Category>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        
        public int? BuyerId { get; set; }

      
        public int SellerId { get; set; }

        
        [InverseProperty("ProductsBought")]
        [ForeignKey("BuyerId")]
        public  virtual User Buyer { get; set; }

       
        [InverseProperty("ProductsSold")]
        [ForeignKey("SellerId")]
        public virtual  User Seller { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
