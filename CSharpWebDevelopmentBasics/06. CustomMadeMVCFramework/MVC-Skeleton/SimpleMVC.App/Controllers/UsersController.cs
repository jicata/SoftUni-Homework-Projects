namespace SimpleMVC.App.Controllers
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Runtime.InteropServices;
    using Data;
    using Models;
    using MVC.Attributes.Methods;
    using MVC.Controllers;
    using MVC.Interfaces;
    using MVC.Interfaces.Generic;
    using MVC.Secutiry;
    using SimpleHttpServer.Models;

    public class UsersController : Controller
    {
        private IDbIdentityContext context;
        private SignInManager signInManager;
        public UsersController()
        {
            this.context = new NotesContext();
            this.signInManager = new SignInManager(this.context);

        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult<User> Register(User user)
        {

            this.context.Users.Add(user);
            this.context.SaveChanges();
            return this.View(user);
        }

        public IActionResult<List<User>> All(HttpSession session)
        {
            if (!this.signInManager.IsAuthenticated(session))
            {
                return this.Redirect("http://localhost:8081/users/login", new List<User>());
            }
            var allUsers = this.context.Users.ToList();
            return this.View(allUsers);
        }

        public IActionResult<User> Profile(int id)
        {
            var user = this.context.Users.FirstOrDefault(u => u.Id == id);
            return this.View(user);
        }

        [HttpPost]
        public IActionResult<User> Profile(Note note)
        {
            var user = this.context.Users.Find(note.UserId);
            user.Notes.Add(note);
            this.context.SaveChanges();
            return this.View(user);
        }

        public IActionResult<SessionViewModel> Greet(HttpSession session)
        {
            var viewModel = new SessionViewModel()
            {
                HttpSessionId = session.Id
            };
            return this.View(viewModel);
        }

        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(User user, HttpSession session)
        {
            User userFromDb =
                this.context.Users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
            if (userFromDb != null)
            {
                var login = new Login()
                {
                    SessionId = session.Id,
                    User = userFromDb,
                    IsActive = true
                };
                this.context.Logins.AddOrUpdate(login);
                this.context.SaveChanges();
                return Redirect("http://localhost:8081/home/index");
            }
            return this.View();
        }
    }
}
