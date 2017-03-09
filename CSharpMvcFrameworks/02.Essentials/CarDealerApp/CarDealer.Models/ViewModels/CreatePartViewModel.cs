namespace CarDealer.Models.ViewModels
{
    using System.Collections.Generic;

    public class CreatePartViewModel
    {
        public CreatePartViewModel()
        {
            this.Suppliers = new List<string>();
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public ICollection<string> Suppliers { get; set; }

        public int SelectedSupplyId { get; set; }
    }
}
