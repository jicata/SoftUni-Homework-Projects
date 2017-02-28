namespace IssueTracker.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Data.Contracts;
    using Data.Security;
    using Data.Services;
    using Models.BindingModels;
    using Models.ViewModels;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;

    public class UsersController : Controller
    {
        private UserService service;
        private SignInManager signInManager;

        public UsersController()
            :this(new IssueTrackerData())
        {
            
        }

        public UsersController(IIssueTrackerData data)
        {
            this.service = new UserService(data);
            this.signInManager = new SignInManager(data);
        }

        [HttpGet]
        public IActionResult<HashSet<RegistrationVerificationErrorViewModel>> Register()
        {
            return this.View(new HashSet<RegistrationVerificationErrorViewModel>());
        }

        [HttpPost]
        public IActionResult<HashSet<RegistrationVerificationErrorViewModel>> Register(HttpResponse response,UserRegisterBindingModel urbm)
        {
            var erros = this.service.ValidateUserRegister(urbm);
            if (erros.Any())
            {
                return this.View(erros);
            }
            if (this.service.RegisterUser(urbm))
            {
                this.Redirect(response, "/users/login");
                return null;
            }
            this.Redirect(response, "/users/register");
            return null;

        }

        [HttpGet]
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(HttpSession session, HttpResponse response, LoginUserBindingModel lubm)
        {
            if (this.service.LoginUser(session, lubm))
            {
                this.Redirect(response, "/home/index");
                return null;
            }
            return this.View();
        }

        public IActionResult Logout(HttpSession session, HttpResponse response)
        {
            this.service.LogoutUser(session,response);
            this.Redirect(response,"/home/index");
            return null;
        }
       
    }
}
