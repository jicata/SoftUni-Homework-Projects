namespace PizzaForum.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BindingModels;
    using Data;
    using Data.Contracts;
    using Models;
    using Security;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;
    using ViewModels;

    public class ForumController : Controller
    {
        private SignInManager signInManager;
        private IPizzaForumData data;

        public ForumController()
            :this(new PizzaForumData())
        {
            
        }

        public ForumController(IPizzaForumData data)
        {
            this.data = data;
            this.signInManager = new SignInManager(this.data.Context);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(HttpResponse response, UserRegisterBindingModel urbm)
        {
            // validations?
            if (urbm.Password == urbm.ConfirmPassword && urbm.Email.Contains("@"))
            {
                var user = new User()
                {
                    Username = urbm.Username,
                    Email = urbm.Email,
                    Password = urbm.Password,
                    IsAdmin = !this.data.Users.GetAll().Any(),
                };
                try
                {
                    this.data.Users.Insert(user);
                    this.data.SaveChanges();
                }
                catch (Exception e)
                {
                    return this.View();
                }
               
                this.Redirect(response, "/forum/login");
                return null;
            }
            return this.View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(HttpResponse response, HttpSession session,LoginUserBindingModel lubm)
        {
            if (!this.signInManager.IsAuthenticated(session))
            {
                User user = null;
                if (lubm.Login.Contains("@"))
                {
                    user = this.data.Users.FindByPredicate(u => u.Email == lubm.Login);                  
                }
                else
                {
                    user = this.data.Users.FindByPredicate(u => u.Username == lubm.Login);
                }

                if (user != null && user.Password == lubm.Password)
                {
                    Login login = new Login()
                    {
                        SessionId = session.Id,
                        User = user,
                        IsActive = true
                    };
                    try
                    {
                        this.data.Logins.Insert(login);
                    }
                    catch (Exception e)
                    {
                        return this.View();
                    }
                    this.data.SaveChanges();
                    this.Redirect(response, "/home/topics");
                    return null;
                }
                return this.View();
            }
            return this.View();
        }
        [HttpPost]
        public IActionResult Profile(HttpResponse response, DeleteTopicBindingModel dtbm)
        {
            var topic = this.data.Topics.FindByPredicate(t => t.Title == dtbm.TopicTitle);
            var replies = topic.Replies.ToList();
            foreach (var reply in replies)
            {
                this.data.Replies.Delete(reply);
            }
            var topicAuthor = topic.Author.Username;
            topic.Author.Topics.Remove(topic);
            this.data.Topics.Delete(topic);
            this.data.SaveChanges();
            this.Redirect(response, $"/forum/profile?ProfileName={topicAuthor}");
            return null;

        }

        public IActionResult<HashSet<TopicViewModel>> Profile(HttpSession session, string profilename)
        {
            var topics = this.data.Users.FindByPredicate(u => u.Username == profilename).Topics;
            HashSet<TopicViewModel> tvms = new HashSet<TopicViewModel>();

            var authenticationTvm = new TopicViewModel();
            authenticationTvm.UserLoggedIn = this.signInManager.IsAuthenticated(session);
            authenticationTvm.Author = profilename;
            tvms.Add(authenticationTvm);

            foreach (var topic in topics)
            {
                TopicViewModel tvm = new TopicViewModel()
                {
                    Author = topic.Author.Username,
                    Category = topic.Category.Name,
                    PostedOn = topic.PublishDate.ToString(),
                    RepliesCount = topic.Replies.Count,
                    Title = topic.Title,
                };
                tvms.Add(tvm);
            }
            return this.View(tvms);
        }

     
    }
}
