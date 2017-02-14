namespace SimpleMVC.App.Controllers
{
    using MVC.Controllers;
    using MVC.Interfaces;

    public class UsersController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

    }
}
