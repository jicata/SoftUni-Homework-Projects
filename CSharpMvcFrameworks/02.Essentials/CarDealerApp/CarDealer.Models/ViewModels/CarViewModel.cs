namespace CarDealer.Models.ViewModels
{
    using System.Collections.Generic;

    public class CarViewModel
    {
        public CarViewModel()
        {
            this.Parts = new List<PartViewModel>();
        }
        public string Make { get; set; }

        public int Id { get; set; }

        public string Model { get; set; }

        public decimal TravelledDistance { get; set; }

       public  IList<PartViewModel> Parts { get; set; }
    }
}
