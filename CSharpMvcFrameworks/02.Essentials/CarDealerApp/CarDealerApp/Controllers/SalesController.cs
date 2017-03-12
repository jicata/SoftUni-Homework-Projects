using System.Web.Mvc;

namespace CarDealerApp.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.ModelBinding;
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.Models;
    using CarDealer.Models.ViewModels;

    [Authorize]
    [RoutePrefix("sales")]
    public class SalesController : Controller
    {
        CarDealerContext context = new CarDealerContext();

        [AllowAnonymous]
        [Route]
        [Route("Index")]
        public ActionResult Index()
        {
            IEnumerable<SaleViewModel> sales =
                Mapper.Map<IEnumerable<Sale>, IEnumerable<SaleViewModel>>(this.context.Sales.ToList());
            return View(sales);
        }

        
        public ActionResult Details(int id)
        {
            SaleViewModel sale = Mapper.Map<SaleViewModel>(this.context.Sales.Find(id));
            return View(sale);
        }

        [AllowAnonymous]
        [Route("{discounted}/{percent?}")]
        public ActionResult Discounted(string discounted, double? percent)
        {
            IEnumerable<SaleViewModel> sales;
            if (percent != null)
            {
                sales =
                    Mapper.Map<IEnumerable<Sale>, IEnumerable<SaleViewModel>>(
                        this.context.Sales.Where(s => s.Discount == percent / 100).ToList());
            }
            else
            {
                sales =
                    Mapper.Map<IEnumerable<Sale>, IEnumerable<SaleViewModel>>(
                        this.context.Sales.Where(s => s.Discount > 0).ToList());
            }
            return this.View(sales);

        }

        // GET: Sales/Create
        [Route("create")]
        public ActionResult Create()
        {
            var cars = this.context.Cars.ToList();
            var customers = this.context.Customers.ToList();
            var addSaleVm = new AddSaleViewModel();
            addSaleVm.Car = cars.Select(x => new SelectListItem()
            {
                Text = $"{x.Make} {x.Model}",
                Value = x.Id.ToString()
            });

            addSaleVm.Customer = customers.Select(x => new SelectListItem()
            {
                Text = $"{x.Name}",
                Value = x.Id.ToString()
            });
            return View(addSaleVm);
        }

        [Route("confirm")]
        public ActionResult Confirm([Bind(Exclude = "Car,Customer")]AddSaleViewModel asvm)
        {
            var car = this.context.Cars.Find(asvm.CarId);
            var customer = this.context.Customers.Find(asvm.CustomerId);
            var price = car.Parts.Sum(p => p.Price);
            var discount = customer.IsYoungDriver ? asvm.Discount + 5 : asvm.Discount;
            var confirmSaleVm = new ConfirmSaleViewModel()
            {
                Car = $"{car.Make} {car.Model}",
                Customer = customer.Name,
                Discount = discount,
                Price = price.Value,
                FinalPrice = decimal.Parse((price.Value - ((discount / 100D) * price.Value)).ToString()),
                CarId = car.Id,
                CustomerId = customer.Id
            };

            return this.View(confirmSaleVm);
        }
        [Route("create")]
        [HttpPost]
        public ActionResult Create([Bind(Include = "CustomerId, CarId, Discount")]ConfirmSaleViewModel csvm)
        {
            Sale sale = new Sale()
            {
                Customer = this.context.Customers.Find(csvm.CustomerId),
                Car = this.context.Cars.Find(csvm.CarId),
                Discount = csvm.Discount/100D
            };
            try
            {
                this.context.Sales.Add(sale);
                this.context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

       [Route("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var sale = this.context.Sales.Find(id);
            this.context.Sales.Remove(sale);
            this.context.SaveChanges();
            return RedirectToAction("Index");
        }
    
    }
}
