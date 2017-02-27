namespace PizzaForum.Controllers
{
    using System.Collections.Generic;
    using Data;
    using Data.Contracts;
    using Models;
    using Security;
    using SimpleHttpServer.Models;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;
    using ViewModels;

    public class HomeController : Controller
    {
        private SignInManager signInManager;
        private IPizzaForumData data;

        public HomeController()
            :this(new PizzaForumData())
        {

        }

        public HomeController(IPizzaForumData data)
        {
            this.data = data;
            this.signInManager = new SignInManager(this.data.Context);
        }

        public IActionResult<HashSet<TopicViewModel>> Topics(HttpResponse response, HttpSession session)
        {
            IEnumerable<Topic> topics = this.data.Topics.GetAll();
            HashSet<TopicViewModel> tvms = new HashSet<TopicViewModel>();

            var authenticationTvm = new TopicViewModel();
            authenticationTvm.UserLoggedIn = this.signInManager.IsAuthenticated(session);
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
        public IActionResult<HashSet<CategoryViewModel>> Categories(HttpSession session, HttpResponse response)
        {
            if (!this.signInManager.IsAuthenticated(session))
            {
                this.Redirect(response, "/home/topics");
                return null;
            }
            var cats = this.data.Categories.GetAll();
            HashSet<CategoryViewModel> cvms = new HashSet<CategoryViewModel>();
            foreach (var category in cats)
            {
                var cvm = new CategoryViewModel()
                {
                    Name = category.Name
                };
                cvms.Add(cvm);
            }
            return this.View(cvms);
        }
    }
}
