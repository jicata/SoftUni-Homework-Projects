namespace Shouter.Controllers
{
    using System.Collections.Generic;
    using BindingModels;
    using Data;
    using Data.Contracts;
    using MVCFramework.MVC.Attributes.Methods;
    using MVCFramework.MVC.Controllers;
    using MVCFramework.MVC.Interfaces;
    using MVCFramework.MVC.Interfaces.Generic;
    using Security;
    using SimpleHttpServer.Models;
    using Tools;
    using ViewModels;

    public class UserController : Controller
    {
        private ShouterData data;
        private SignInManager signInManager;

        public UserController()
            : this(new ShouterContext())
        {

        }
        public UserController(IShouterContext context)
        {
            this.data = new ShouterData(context);
            this.signInManager = new SignInManager(this.data.Context);
        }

        public IActionResult<List<ShoutViewModel>> Feed(HttpResponse response, HttpSession session)
        {
            if (this.signInManager.IsAuthenticated(session))
            {
                var user = this.data.LoginRepository.FindUserByLogin(session.Id);
                var shouts = this.data.ShoutRepository.UpdateAndGetAllShouts(s => s.Author.Id == user.Id);
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
            this.Redirect(response, "/home/login");
            return null;
        }

        [HttpPost]
        public IActionResult Feed(HttpResponse response, ShoutBindingModel sbm)
        {
            var shout = this.data.ShoutRepository.FindByPredicate(s => s.Content == sbm.Content);
            this.data.ShoutRepository.Delete(shout);
            this.data.SaveChanges();
            Redirect(response, "/user/feed");
            return null;
        }

        public IActionResult<List<UserViewModel>> Followers(HttpSession session, HttpResponse response)
        {
            if (this.signInManager.IsAuthenticated(session))
            {
                var currentUser = this.data.LoginRepository.FindUserByLogin(session.Id);
                var userViewModels = new List<UserViewModel>();
                foreach (var user in currentUser.Following)
                {
                    var userViewModel = new UserViewModel()
                    {
                        Id = user.Id,
                        Username = user.Username
                    };
                    userViewModels.Add(userViewModel);
                }
                return this.View(userViewModels);
            }
            this.Redirect(response, "/home/login");
            return null;

        }

        public IActionResult<List<NotificationViewModel>> Notifications(HttpSession session, HttpResponse response)
        {
            if (this.signInManager.IsAuthenticated(session))
            {
                var currentUser = this.data.LoginRepository.FindUserByLogin(session.Id);
                var notificationViewModels = new List<NotificationViewModel>();
                foreach (var currentUserNotification in currentUser.Notifications)
                {
                    var notificationViewModel = new NotificationViewModel()
                    {
                        UserId = currentUserNotification.ShoutAuthor.Id,
                        Username = currentUserNotification.ShoutAuthor.Username
                    };
                    notificationViewModels.Add(notificationViewModel);
                }
                return this.View(notificationViewModels);
            }
            this.Redirect(response, "/home/login");
            return null;
        }
    }
}