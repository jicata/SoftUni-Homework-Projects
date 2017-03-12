namespace CarDealer.Models.ViewModels
{
    using System.ComponentModel;

    public class ConfirmSaleViewModel
    {
        public string Customer { get; set; }

        public string Car { get; set; }

        public double Discount { get; set; }

        [DisplayName("Car Price")]
        public double Price { get; set; }

        [DisplayName("Final Price")]
        public decimal FinalPrice { get; set; }

        public int CarId { get; set; }
        
        public int CustomerId { get; set; }
    }
}
