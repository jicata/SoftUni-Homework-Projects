using System.Web.Mvc;

namespace CarDealerApp.Controllers
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.Models;
    using CarDealer.Models.BindingModels;
    using CarDealer.Models.ViewModels;

    [RoutePrefix("parts")]
    public class PartsController : Controller
    {
        CarDealerContext context = new CarDealerContext();
        // GET: Parts
        public ActionResult Index()
        {
            return View(this.context.Parts.ToList());
        }

        // GET: Parts/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        [Route("Create")]
        // GET: Parts/Create
        public ActionResult Create()
        {
            var suppliers = this.context.Suppliers.Select(s => s.Name).ToList();
            var createPartVs = new CreatePartViewModel() { Suppliers = suppliers };
            return View(createPartVs);

        }

        // POST: Parts/Create
        [HttpPost]
        [Route("create")]
        public ActionResult Create(CreatePartBindingModel cpbm)
        {
           
            try
            {
                var supplier = this.context.Suppliers.FirstOrDefault(s => s.Name == cpbm.Supplier);
                var part = Mapper.Map<Part>(cpbm);
                part.Supplier = supplier;
                this.context.Parts.Add(part);
                this.context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Parts/Edit/5
        public ActionResult Edit(int id)
        {
            var part = Mapper.Map<PartEditViewModel>(this.context.Parts.Find(id));

            return View(part);
        }

        // POST: Parts/Edit/5
        [HttpPost]
        public ActionResult Edit(PartEditViewModel pevm)
        {
           
            try
            {
                var part = this.context.Parts.Find(pevm.Id);
                part.Price = pevm.Price;
                part.Quantity = pevm.Quantity;

                this.context.Parts.AddOrUpdate(part);
                this.context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Parts/Delete/5
        public ActionResult Delete(int id)
        {

            var part = this.context.Parts.Find(id);
            return View(part);
        }

        // POST: Parts/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            try
            {

                var part = this.context.Parts.Find(id);
                this.context.Parts.Remove(part);
                this.context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
