namespace CarDealer.Models.ViewModels
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class AddSaleViewModel
    {
        public int CarId { get; set; }
        public IEnumerable<SelectListItem> Car { get; set; }
        public int CustomerId { get; set; }
        public IEnumerable<SelectListItem> Customer { get; set; }

        public double Discount { get; set; }
    }
}
