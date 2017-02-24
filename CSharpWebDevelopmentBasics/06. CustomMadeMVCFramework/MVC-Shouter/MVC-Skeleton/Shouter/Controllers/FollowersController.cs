namespace Shouter.Controllers
{
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

    public class FollowersController : Controller
    {
        private ShouterData data;
        private SignInManager signInManager;

        public FollowersController()
            :this(new ShouterContext())
        {

        }
        public FollowersController(IShouterContext context)
        {
            this.data = new ShouterData(context);
            this.signInManager = new SignInManager(this.data.Context);
        }

        public IActionResult<List<FollowerViewModel>> All(HttpResponse response, HttpSession session, string query = null)
        {
            if (this.signInManager.IsAuthenticated(session))
            {
                var currentUser = this.data.LoginRepository.FindUserByLogin(session.Id);
                IQueryable<User> allUsers;
                if (query != null)
                {
                    allUsers =
                        this.data.UsersRepository.Find(u => u.Username != currentUser.Username && u.Username.Contains(query));
                }
                else
                {
                    allUsers = this.data.UsersRepository.Find(u => u.Username != currentUser.Username);
                }
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
           this.Redirect(response, "/home/login");
            return null;
        }

        [HttpPost]
        public IActionResult All(HttpResponse response, HttpSession session, FollowerBindingModel fvm)
        {
            if (this.signInManager.IsAuthenticated(session))
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
                this.data.SaveChanges();
                Redirect(response, "/followers/all");
                return null;
            }
            this.Redirect(response, "/home/login");
            return null;

        }

        public IActionResult<List<ShoutViewModel>> Feed(HttpResponse response, HttpSession session)
        {
            if (this.signInManager.IsAuthenticated(session))
            {
                var user = this.data.LoginRepository.FindUserByLogin(session.Id);
                List<string> userFollowersUsernames = new List<string>();
                foreach (var userFollower in user.Following)
                {
                    userFollowersUsernames.Add(userFollower.Username);
                }
                var shouts = this.data.ShoutRepository.UpdateAndGetAllShouts(s=>userFollowersUsernames.Contains(s.Author.Username));
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

        public IActionResult<UserProfileViewModel> Profile(HttpSession session, int id)
        {
            var currentUser = this.data.LoginRepository.FindUserByLogin(session.Id);
            var user = this.data.UsersRepository.GetById(id);
            var shoutsByUser = this.data.ShoutRepository.Find(s => s.Author.Id == user.Id);
            string followStatus = string.Empty;
            string followOption = string.Empty;
            bool isFollowing = currentUser.Following.Contains(user);
            if (isFollowing)
            {
                followStatus = "danger";
                followOption = "Unfollow";
            }
            else
            {
                followStatus = "success";
                followOption = "Follow";
            }
            var userProfileModel = new UserProfileViewModel()
            {
                Username = user.Username,
                FollowOption = followOption,
                FollowStatus = followStatus
            };
            foreach (var userShout in shoutsByUser)
            {
                var shoutViewModel = new ShoutViewModel()
                {
                    Author = user,
                    Content = userShout.Content,
                    PostedForTime = Extensions.CalculateTimeSincePost(userShout.PostedOn)
                };
                userProfileModel.Shouts.Add(shoutViewModel);
            }
            return this.View(userProfileModel);
        }
    }
}
