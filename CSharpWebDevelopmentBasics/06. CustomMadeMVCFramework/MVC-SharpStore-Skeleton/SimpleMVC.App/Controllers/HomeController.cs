namespace SharpStore.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Microsoft.Win32;
    using Models;
    using MVCFramework.MVC.Attributes.Methods;
    using MVCFramework.MVC.Controllers;
    using MVCFramework.MVC.Interfaces;
    using MVCFramework.MVC.Interfaces.Generic;
    using SimpleHttpServer.Enums;
    using SimpleHttpServer.Models;

    public class HomeController : Controller
    {
        private SharpStoreContext context;


        public HomeController()
        {
            this.context = new SharpStoreContext();
        }
        [HttpGet]
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult About()
        {
            return this.View();
        }

        public IActionResult<List<Knife>> Products(string query=null)
        {
            if (query != null)
            {
                var selectedKnives = this.context.Knives.Where(k => k.Name.Contains(query));
                return this.View(selectedKnives.ToList());
            }
            return this.View(this.context.Knives.ToList());
        }
        [HttpPost]
        public IActionResult Products(HttpResponse response)
        {
            this.Redirect(response, "/home/buy");
            return null;
        }

        public IActionResult Contacts()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Contacts(Message message)
        {
            context.Messages.Add(message);
            context.SaveChanges();
            return this.View();
        }

        public IActionResult Buy()
        {
            return this.View();
        }
        
        [HttpPost]
        public IActionResult Buy(Buyer buyer)
        {
            this.context.Buyers.Add(buyer);
            this.context.SaveChanges();
            return this.View();
        }

        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(HttpResponse response,User user)
        {
            var userFromDb =
                this.context.Users.FirstOrDefault(u => u.Password == user.Password && u.Username == user.Username);
            if (userFromDb != null)
            {
                this.Redirect(response, "/admin/home");
                return null;
            }
            else
            {
                return this.View();
            }
        }
    }
}
