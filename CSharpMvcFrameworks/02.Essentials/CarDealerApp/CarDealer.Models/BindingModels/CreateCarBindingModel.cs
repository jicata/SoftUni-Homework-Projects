namespace CarDealer.Models.BindingModels
{
    using System.Collections.Generic;
    using ViewModels;

    public class CreateCarBindingModel
    {
        public CreateCarBindingModel()
        {
            this.Parts = new List<PartViewModel>();
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        public ICollection<PartViewModel> Parts { get; set; }
    }
}
