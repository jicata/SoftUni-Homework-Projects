namespace SimpleMVC.App.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using Data;
    using Models;
    using MVC.Attributes.Methods;
    using MVC.Controllers;
    using MVC.Interfaces;
    using MVC.Interfaces.Generic;

    public class UsersController : Controller
    {
        private NotesContext context;
        public UsersController()
        {
            context = new NotesContext();
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

        public IActionResult<List<User>> All()
        {         
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

    }
}
