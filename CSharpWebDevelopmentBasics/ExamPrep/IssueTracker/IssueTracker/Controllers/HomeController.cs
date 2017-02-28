namespace IssueTracker.Web.Controllers
{
    using Data;
    using Data.Contracts;
    using Data.Security;
    using Data.Services;
    using Models.ViewModels;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces.Generic;

    public class HomeController : Controller
    {
        private HomeService service;
        private SignInManager signInManager;

        public HomeController()
            :this(new IssueTrackerData())
        {

        }

        public HomeController(IIssueTrackerData data)
        {
            this.service = new HomeService(data);
            this.signInManager = new SignInManager(data);
        }

        [HttpGet]
        public IActionResult<LoggedInUserViewModel> Index(HttpSession session)
        {
            return this.View(this.service.CheckedForLoggedInUser(session));
        }
    }
}
