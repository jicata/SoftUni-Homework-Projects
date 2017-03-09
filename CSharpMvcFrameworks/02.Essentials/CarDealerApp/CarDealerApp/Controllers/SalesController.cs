using System.Web.Mvc;

namespace CarDealerApp.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.Models;
    using CarDealer.Models.ViewModels;

    [RoutePrefix("sales")]
    public class SalesController : Controller
    {
        CarDealerContext context = new CarDealerContext();

        [Route]
        [Route("Index")]
        public ActionResult Index()
        {
            IEnumerable<SaleViewModel> sales =
                Mapper.Map<IEnumerable<Sale>, IEnumerable<SaleViewModel>>(this.context.Sales.ToList());
            return View(sales);
        }

        // GET: Sales/Details/5
        public ActionResult Details(int id)
        {
            SaleViewModel sale = Mapper.Map<SaleViewModel>(this.context.Sales.Find(id));
            return View(sale);
        }

        [Route("{discounted}/{percent?}")]
        public ActionResult Discounted(string discounted, double? percent)
        {
            IEnumerable<SaleViewModel> sales;
            if (percent != null)
            {
                sales =
                    Mapper.Map<IEnumerable<Sale>, IEnumerable<SaleViewModel>>(
                        this.context.Sales.Where(s => s.Discount == percent/100).ToList());
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sales/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sales/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Sales/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sales/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sales/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
