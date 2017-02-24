namespace Shouter.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BindingModels;
    using Data;
    using Data.Contracts;
    using Models;
    using MVCFramework.MVC.Attributes.Methods;
    using MVCFramework.MVC.Controllers;
    using MVCFramework.MVC.Interfaces;
    using MVCFramework.MVC.Interfaces.Generic;
    using Security;
    using SimpleHttpServer.Models;
    using Tools;
    using ViewModels;

    public class HomeController : Controller
    {
        private ShouterData data;
        private SignInManager signInManager;

        public HomeController()
            :this(new ShouterContext())
        {
            
        }
        public HomeController(IShouterContext context)
        {
            this.data = new ShouterData(context);
            this.signInManager = new SignInManager(this.data.Context);
        }

        public IActionResult<List<ShoutViewModel>> FeedSigned(HttpResponse response, HttpSession session)
        {
            if (this.signInManager.IsAuthenticated(session))
            {
                var shouts = this.data.ShoutRepository.UpdateAndGetAllShouts();
                var shoutViewModels = new List<ShoutViewModel>();
                foreach (var shout in shouts)
                {
                    var shoutViewModel = new ShoutViewModel()
                    {
                        Author = shout.Author,
                        Content = shout.Content,
                        PostedForTime = Extensions.CalculateTimeSincePost(shout.PostedOn)
                    };
                    shoutViewModels.Add(shoutViewModel);
                }
                this.data.SaveChanges();
                return this.View(shoutViewModels);
            }
            else
            {
                this.Redirect(response,"/home/feed");
                return null;
            }
        }

        [HttpPost]
        public IActionResult FeedSigned(HttpResponse response, HttpSession session, ShoutBindingModel sbm)
        {
            var user = this.data.LoginRepository.FindUserByLogin(session.Id);
            var shout = new Shout()
            {
                Author = user,
                Content = sbm.Content,
                PostedOn = DateTime.Now
            };
            if (sbm.Lifetime != 0)
            {
                shout.Lifetime = new TimeSpan(sbm.Lifetime, 59, 59);
            }
            var notification = new Notification()
            {
                ShoutAuthor = user
            };
            var followedBy = this.data.UsersRepository.Find(u => u.Following.Select(f => f.Id).Contains(user.Id));
            foreach (var follower in followedBy)
            {
                follower.Notifications.Add(notification);
            }
            this.data.ShoutRepository.Insert(shout);
            this.data.SaveChanges();
            Redirect(response,"/home/feedSigned");
            return null;
        }


        public IActionResult<List<ShoutViewModel>> Feed(HttpResponse response, HttpSession session)
        {
            if (this.signInManager.IsAuthenticated(session))
            {
                Redirect(response, "/home/feedSigned");
                return null;
            }

            var shouts = this.data.ShoutRepository.UpdateAndGetAllShouts();
            var shoutViewModels = new List<ShoutViewModel>();
            foreach (var shout in shouts)
            {
                var shoutViewModel = new ShoutViewModel()
                {
                    Author = shout.Author,
                    Content = shout.Content,
                    PostedForTime = Extensions.CalculateTimeSincePost(shout.PostedOn)
                };
                shoutViewModels.Add(shoutViewModel);
            }
            this.data.SaveChanges();
            return this.View(shoutViewModels);
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(HttpResponse response, RegisterUserBindingModel rubm)
        {
            if (rubm.Password == rubm.ConfirmedPassword)
            {
                var user = new User()
                {
                    Birthdate = DateTime.Parse(rubm.Birthdate),
                    Email = rubm.Email,
                    Password = rubm.Password,
                    Username = rubm.Username
                };
                this.data.UsersRepository.Insert(user);
                this.data.SaveChanges();
                this.Redirect(response, "/home/feed");
                return null;
            }
            return this.View();
        }

        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(HttpResponse response, HttpSession session, LoginUserBindingModel lubm)
        {
            var user = this.data.UsersRepository.FindUserByUserName(lubm.Username);
            if (user != null && user.Password == lubm.Password)
            {
                this.data.LoginRepository.CreateLogin(session.Id, user);
                this.data.SaveChanges();

                this.Redirect(response, "/home/feedSigned");
                return null;
            }
            return this.View();
        }

        public IActionResult Logout(HttpResponse response, HttpSession session)
        {
            var login = this.data.LoginRepository.FindByPredicate(l => l.SessionId == session.Id);
            this.data.LoginRepository.Delete(login);
            this.data.SaveChanges();
            this.Redirect(response,"/home/feed");
            return null;

        }
    }
}
