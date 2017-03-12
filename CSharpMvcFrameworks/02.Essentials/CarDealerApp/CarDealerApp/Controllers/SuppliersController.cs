using System.Web.Mvc;

namespace CarDealerApp.Controllers
{
    using System.Linq;
    using CarDealer.Data;
    using CarDealer.Models;

    [Authorize]
    [RoutePrefix("suppliers")]
    public class SuppliersController : Controller
    {   
        CarDealerContext db = new CarDealerContext();
        // GET: Suppliers

        [AllowAnonymous]
        [Route("{type}")]
        public ActionResult All(string type)
        {
            bool isImporter = type?.ToLower() == "importers";

            var suppliers = this.db.Suppliers.Where(s => s.IsImporter == isImporter);

            return this.View(suppliers);
        }

        [Route("delete")]
        public ActionResult Delete(int id)
        {
            var supplier = this.db.Suppliers.Find(id);
            return View(supplier);
        }


        // POST: Suppliers/Delete/5
        [Route("delete")]
        [HttpPost]
        public ActionResult Delete(Supplier supplier)
        {
            var supplierFromDb = this.db.Suppliers.Find(supplier.Id);
            try
            {
                this.db.Suppliers.Remove(supplierFromDb);
                this.db.SaveChanges();
                return RedirectToAction("All", new {type="importers"});
            }
            catch
            {
                return View();
            }
        }



        // GET: Suppliers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
       
    }
}
