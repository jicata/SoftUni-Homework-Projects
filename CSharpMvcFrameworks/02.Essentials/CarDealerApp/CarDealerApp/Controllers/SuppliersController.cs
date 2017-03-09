using System.Web.Mvc;

namespace CarDealerApp.Controllers
{
    using System.Linq;
    using CarDealer.Data;

    [RoutePrefix("suppliers")]
    public class SuppliersController : Controller
    {   
        CarDealerContext db = new CarDealerContext();
        // GET: Suppliers

        [Route("{type?}")]
        public ActionResult Suppliers(string type)
        {
            bool isImporter = type.ToLower() == "importers";

            var suppliers = this.db.Suppliers.Where(s => s.IsImporter == isImporter);

            return this.View(suppliers);
        }
        // GET: Suppliers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Suppliers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Suppliers/Create
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

        // GET: Suppliers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Suppliers/Edit/5
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

        // GET: Suppliers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Suppliers/Delete/5
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
