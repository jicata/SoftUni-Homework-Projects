namespace SoftUniStore.Client.Controllers
{
    using Data;
    using Data.Contracts;
    using Data.Services;
    using Models.BIndingModels;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;

    public class UsersController : Controller
    {
        private UsersService service;

        public UsersController()
            : this(new SoftStoreData())
        {

        }

        public UsersController(ISoftStoreData data)
        {
            this.service = new UsersService(data);
        }

        public IActionResult Register(HttpSession session, HttpResponse response)
        {
            if (this.service.IsUserLoggedInOrRegistered(session))
            {
                this.Redirect(response, "/home/index");
                return null;
            }
            return this.View();

        }

        [HttpPost]
        public IActionResult Register(HttpResponse response, UserRegisterBindingModel urbm, HttpSession session)
        {
            if (this.service.IsUserLoggedInOrRegistered(session))
            {
                this.Redirect(response, "/home/index");
                return null;
            }

            bool verified = this.service.VerifyRegistration(urbm);
            if (verified)
            {
                this.service.Register(urbm);
                this.Redirect(response, "/users/login");
                return null;
            }
            this.Redirect(response, "/users/register");
            return null;
        }

        public IActionResult Login(HttpSession session, HttpResponse response)
        {
            if (this.service.IsUserLoggedInOrRegistered(session))
            {
                this.Redirect(response, "/home/index");
                return null;
            }
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(HttpSession session, HttpResponse response, UserLoginBindingModel ulbm)
        {
            if (this.service.IsUserLoggedInOrRegistered(session))
            {
                this.Redirect(response, "/home/index");
                return null;
            }
            bool successfulLogin = this.service.LogUserIn(session, ulbm);
            if (successfulLogin)
            {
                this.Redirect(response, "/home/index");
                return null;
            }

            this.Redirect(response, "/users/login");
            return null;

        }

        public IActionResult Logout(HttpSession session, HttpResponse response)
        {
            this.service.LogoutUser(session);
            this.Redirect(response,"/home/index");
            return null;
        }
    }
}
