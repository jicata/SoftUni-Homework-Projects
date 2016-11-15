using System.Web.Mvc;

namespace BankSystem.Web.Controllers
{
    using System.Linq;
    using Data;

    public class HomeController : Controller
    {
        BankSystemContext context = new BankSystemContext();
        // GET: Home
        public ActionResult Index()
        {
            var user = this.context.Users.First();
            return View(user);
        }
    }
}