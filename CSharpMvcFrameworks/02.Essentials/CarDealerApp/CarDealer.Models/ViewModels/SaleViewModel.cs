namespace CarDealer.Models.ViewModels
{
    using System.ComponentModel;
    using System.Diagnostics.Eventing.Reader;

    public class SaleViewModel
    {
        private decimal totalSumWithDiscount;
        public int Id { get; set; }

        public decimal Discount { get; set; }

        [DisplayName("Car make")]
        public string CarMake { get; set; }

        [DisplayName("Car model")]
        public string CarModel { get; set; }

        public decimal TravelledDistance { get; set; }

        [DisplayName("Customer name")]
        public string CustomerName { get; set; }

        public decimal TotalSum { get; set; }

        public decimal TotalSumWithDiscount
        {
            get { return this.totalSumWithDiscount; }
            set {
                this.totalSumWithDiscount = value == 0 ? this.TotalSum : value;
            }
        }
    }
}
