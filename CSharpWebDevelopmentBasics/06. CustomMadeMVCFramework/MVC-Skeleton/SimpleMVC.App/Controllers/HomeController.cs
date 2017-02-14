namespace SimpleMVC.App.Controllers
{
    using MVC.Controllers;
    using MVC.Interfaces;

    public class HomeController :Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
