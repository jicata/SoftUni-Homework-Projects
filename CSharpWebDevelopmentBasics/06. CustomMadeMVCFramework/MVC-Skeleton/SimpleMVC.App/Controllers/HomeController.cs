namespace SimpleMVC.App.Controllers
{
    using System.Linq;
    using Data;
    using MVC.Attributes.Methods;
    using MVC.Controllers;
    using MVC.Interfaces;
    using MVC.Secutiry;
    using SimpleHttpServer.Models;

    public class HomeController :Controller
    {
        private SignInManager signInManager;
        private NotesContext context;

        public HomeController()
        {
            this.context = new NotesContext();
            this.signInManager = new SignInManager(this.context);
        }
        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Index(HttpSession session)
        {
            if (this.signInManager.IsAuthenticated(session))
            {
                var login = this.context.Logins.FirstOrDefault(l => l.SessionId == session.Id);
                this.context.Logins.Remove(login);
                this.context.SaveChanges();
            }
            return this.View();
        }
    }
}
