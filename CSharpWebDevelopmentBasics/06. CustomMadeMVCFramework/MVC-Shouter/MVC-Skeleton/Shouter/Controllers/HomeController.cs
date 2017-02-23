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
    using ViewModels;
    using Views.Home;

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
                        PostedForTime = this.CalculateTimeSincePost(shout.PostedOn)
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
                Lifetime = new TimeSpan(sbm.Lifetime, 59, 59),
                PostedOn = DateTime.Now
            };
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
                    PostedForTime = this.CalculateTimeSincePost(shout.PostedOn)
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

        public IActionResult FollowersFeed(HttpResponse response, HttpSession session)
        {
            if (this.signInManager.IsAuthenticated(session))
            {
                return this.View();
            }
            this.Redirect(response, "/home/login");
            return null;
        }


        public IActionResult Logout(HttpResponse response, HttpSession session)
        {
            var login = this.data.LoginRepository.FindByPredicate(l => l.SessionId == session.Id);
            this.data.LoginRepository.Delete(login);
            this.data.SaveChanges();
            this.Redirect(response,"/home/feed");
            return null;

        }

        public IActionResult<List<FollowerViewModel>> Followers(HttpSession session)
        {
            var currentUser = this.data.LoginRepository.FindUserByLogin(session.Id);
            var allUsers = this.data.UsersRepository.Find(u => u.Username != currentUser.Username);        
            var userFollowing = currentUser.Following.ToList();
            List<FollowerViewModel> fvms = new List<FollowerViewModel>();
            foreach (var user in allUsers)
            {
                var fvm = new FollowerViewModel()
                {
                    Username = user.Username,
                    Id = user.Id.ToString()
                };
                if (userFollowing.Contains(user))
                {
                    fvm.FollowOption = "Unfollow";
                    fvm.FollowStatus = "danger";
                }
                else
                {
                    fvm.FollowOption = "Follow";
                    fvm.FollowStatus = "success";
                }
                fvms.Add(fvm);
            }
            return this.View(fvms);
        }

        [HttpPost]
        public IActionResult Followers(HttpResponse response, HttpSession session, FollowerBindingModel fvm)
        {
            var user = this.data.LoginRepository.FindUserByLogin(session.Id);
            var follower = this.data.UsersRepository.GetById(fvm.Id);
            if (user.Following.Contains(follower))
            {
                user.Following.Remove(follower);
            }
            else
            {
                user.Following.Add(follower);
            }
           
            //this.data.UsersRepository.AddOrUpdateUser(user);
            this.data.SaveChanges();
            Redirect(response,"/home/followers");
            return null;
        }
        private string CalculateTimeSincePost(DateTime? shoutPostedOn)
        {
            DateTime now = DateTime.Now;
            TimeSpan timeSincePost = now - shoutPostedOn.Value;
            if (timeSincePost.Seconds < 5)
            {
                return "less than a second";
            }
            else if (timeSincePost.Minutes < 1)
            {
                return "less than a minute";
            }
            else if (timeSincePost.Hours < 1)
            {
                return $"{timeSincePost.Minutes} minutes ago";
            }
            else if (timeSincePost.Days < 1)
            {
                return $"{timeSincePost.Hours} hours ago";
            }
            else if (timeSincePost.Days < 30)
            {
                return $"{timeSincePost.Days} days ago";
            }
            else if (timeSincePost.Days < 365)
            {
                return $"{timeSincePost.Days / 30} months ago";
            }
            else
            {
                return "more than an year ago";
            }
        }
    }
}
