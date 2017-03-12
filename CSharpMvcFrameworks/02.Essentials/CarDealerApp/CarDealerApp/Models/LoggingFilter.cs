using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealerApp.Models
{
    using System.Web.Mvc;
    using CarDealer.Data;
    using CarDealer.Models;

    public class LoggingFilter: ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            using (CarDealerContext context = new CarDealerContext())
            {
                var log = new Log()
                {
                    Action = filterContext.ActionDescriptor.ActionName,
                    Controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                    Time = DateTime.Now,
                    User = HttpContext.Current.User.Identity.IsAuthenticated ? HttpContext.Current.User.Identity.Name : "anon"
                };
                context.Logs.Add(log);
                context.SaveChanges();
            }
            base.OnActionExecuting(filterContext);
        }
    }
}