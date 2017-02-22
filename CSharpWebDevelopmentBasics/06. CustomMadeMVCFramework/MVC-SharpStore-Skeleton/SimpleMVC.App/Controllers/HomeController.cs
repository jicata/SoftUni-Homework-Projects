namespace SharpStore.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Models;
    using MVCFramework.MVC.Attributes.Methods;
    using MVCFramework.MVC.Controllers;
    using MVCFramework.MVC.Interfaces;
    using MVCFramework.MVC.Interfaces.Generic;
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
            buyer.DeliveryStatus = "Pending";
            this.context.Buyers.Add(buyer);
            this.context.SaveChanges();
            return this.View();
        }

        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(HttpResponse response,User user, HttpSession session)
        {
            var userFromDb =
                this.context.Users.FirstOrDefault(u => u.Password == user.Password && u.Username == user.Username);
            
            if (userFromDb != null)
            {
                if(!this.context.Logins.Any(l => l.User.Id == userFromDb.Id && l.IsActive))
                {
                    var login = new Login()
                    {
                        IsActive = true,
                        SessionId = session.Id,
                        User = userFromDb
                    };
                    this.context.Logins.Add(login);
                    this.context.SaveChanges();
                    return this.View();
                }
                Redirect(response, "/home/products");
                return null;
            }
            else
            {
                return this.View();
            }
        }

        public IActionResult Logout(HttpResponse response, HttpSession session)
        {
            var login = this.context.Logins.FirstOrDefault(l => l.SessionId == session.Id);
            if (login != null)
            {
                this.context.Logins.Remove(login);
                this.context.SaveChanges();
                Redirect(response,"/home/index");
                return null;
            }
            Redirect(response,"home/login");
            return null;
        }
    }
}
