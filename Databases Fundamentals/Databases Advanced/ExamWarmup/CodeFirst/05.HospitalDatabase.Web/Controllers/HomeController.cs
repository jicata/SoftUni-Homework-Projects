using System.Web.Mvc;

namespace _05.HospitalDatabase.Web.Controllers
{
    using System.Linq;
    using Data;

    public class HomeController : Controller
    {
        HospitalContext context = new HospitalContext();
        public ActionResult Index()
        {
            var model = this.context.Patients.First();
            return View(model);
        }
    }
}