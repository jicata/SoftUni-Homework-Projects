namespace CarDealer.Models.BindingModels
{
    public class CreatePartBindingModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string Supplier { get; set; }

        public int SelectedSupplyId { get; set; }
    }
}
