using System.Web.Mvc;

namespace CarDealerApp.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using CarDealer.Data;
    using CarDealer.Models;
    using PagedList;

    [RoutePrefix("logs")]
    public class LogsController : Controller
    {
        CarDealerContext context = new CarDealerContext();
        [Route("all")]
        // GET: Logs
        public ActionResult All(string search, int? page)
        {
            List<Log> logs;
            if (string.IsNullOrEmpty(search))
            {
                logs = this.context.Logs.OrderBy(l=>l.Time).ToList();
                //page = ViewBag.CurrentFilter;
            }
            else
            {
                page = 1;
                ViewBag.CurrentFilter = search;
                logs = this.context.Logs.Where(l => l.User == search).OrderBy(l=>l.Time).ToList();
            }
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return View(logs.ToPagedList(pageNumber,pageSize));
        }

        [Authorize]
        [Route("Clear")]
        public ActionResult Clear()
        {
            var logs = this.context.Logs;
            this.context.Logs.RemoveRange(logs);
            this.context.SaveChanges();
            return this.RedirectToAction("All");
        }
    }
}