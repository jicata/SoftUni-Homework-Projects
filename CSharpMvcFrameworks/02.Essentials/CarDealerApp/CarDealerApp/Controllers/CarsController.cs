using System.Web.Mvc;

namespace CarDealerApp.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.Models;
    using CarDealer.Models.BindingModels;
    using CarDealer.Models.ViewModels;

    [RoutePrefix("cars")]
    public class CarsController : Controller
    {
        private CarDealerContext db = new CarDealerContext();

        // GET: Cars
        [Route("{make}")]
        public ActionResult Cars(string make)
        {
            List<Car> cars =
                this.db.Cars.Where(c => c.Make == make).OrderBy(c => c.Model).ThenBy(c => c.TravelledDistance).ToList();
            return this.View(cars);
        }

        // GET: Cars/Details/5
        [Route("{id}/parts")]
        public ActionResult Details(int? id)
        {
            var car = this.db.Cars.FirstOrDefault(c => c.Id == id);
            var parts = car.Parts;
            var carVm = Mapper.Map<Car, CarViewModel>(car);
            List<PartViewModel> partVms = new List<PartViewModel>();
            foreach (var part in parts)
            {
                var partVm = Mapper.Map<Part, PartViewModel>(part);
                partVms.Add(partVm);
            }
            carVm.Parts = partVms;
            return this.View(carVm);
        }

        [Route("all")]
        public ActionResult All()
        {
            return this.View(this.db.Cars.ToList());
        }

        // POST: Cars/Create

        [Authorize()]
        [Route("create")]
        public ActionResult Create()
        {
            var createCarBm = new CarViewModel();
            var partVms = Mapper.Map<IEnumerable<Part>, IEnumerable<PartViewModel>>(this.db.Parts.ToList());
            createCarBm.Parts = partVms.ToList();
            return this.View(createCarBm);
        }


        [Route("create")]
        [HttpPost]
        public ActionResult Create(CreateCarBindingModel ccbm)
        {
            try
            {
                var parts = ccbm.Parts.Where(p => p.Checked);
                var car = Mapper.Map<Car>(ccbm);
                foreach (var part in parts)
                {
                    var partFromDb = this.db.Parts.FirstOrDefault(p => p.Name == part.Name);
                    car.Parts.Add(partFromDb);
                }
                this.db.Cars.Add(car);
                this.db.SaveChanges();
                return RedirectToAction("All");
            }
                catch
            {
                return View();
            }
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int id)
        {

            return View();
        }

        // POST: Cars/Edit/5
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

        // GET: Cars/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cars/Delete/5
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
