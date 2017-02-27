namespace PizzaForum.Controllers
{
    using System;
    using System.Collections.Generic;
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

    public class TopicsController : Controller
    {
        private SignInManager signInManager;
        private IPizzaForumData data;

        public TopicsController()
            :this(new PizzaForumData())
        {

        }

        public TopicsController(IPizzaForumData data)
        {
            this.data = data;
            this.signInManager = new SignInManager(this.data.Context);
        }

        public IActionResult<HashSet<CategoryViewModel>> New()
        {
            var cats = this.data.Categories.GetAll();
            HashSet<CategoryViewModel> cvms = new HashSet<CategoryViewModel>();
            foreach (var category in cats)
            {
                CategoryViewModel cvm = new CategoryViewModel()
                {
                    Name = category.Name
                };
                cvms.Add(cvm);
            }
            return this.View(cvms);
        }

        [HttpPost]
        public IActionResult New(HttpSession session, HttpResponse response,AddTopicBindingModel atbm)
        {
            bool isTopicValid = this.ValidateTopic(atbm);
            if (isTopicValid)
            {
                var user = this.data.Logins.FindByPredicate(l => l.SessionId == session.Id).User;

                Topic topic = new Topic()
                {
                    Author = user,
                    Category = this.data.Categories.FindByPredicate(c => c.Name == atbm.Category),
                    Content = atbm.Content,
                    PublishDate = DateTime.Now,
                    Title = atbm.Title
                };
                this.data.Topics.Insert(topic);
                this.data.SaveChanges();
                this.Redirect(response,"/home/topics");
                return null;
            }
            this.Redirect(response,"/topics/new");
            return null;

        }

        public IActionResult<TopicDetailsViewModel> Details(HttpSession session,string topicTitle)
        {
           
            var topic = this.data.Topics.FindByPredicate(t => t.Title == topicTitle);
            var tdvm = new TopicDetailsViewModel()
            {
                Title = topic.Title,
                Author = topic.Author.Username,
                Content = topic.Content,
                PostedOn = topic.PublishDate.Value.ToString(),
                UserLogged = this.signInManager.IsAuthenticated(session)
            };
           
            foreach (Reply reply in topic.Replies)
            {
                ReplyViewModel rvm = new ReplyViewModel()
                {
                    Author = reply.Author.Username,
                    Content = reply.Content,
                    Date = reply.PublishDate.ToString(),
                    ImgUrl = reply.ImageUrl

                };
                 tdvm.ReplyViewModels.Add(rvm);
            }
            
            return this.View(tdvm);
        }

        [HttpPost]
        public IActionResult Details(HttpSession session, HttpResponse response, AddReplyBindingModel arbm)
        {
            var user = this.data.Logins.FindByPredicate(l => l.SessionId == session.Id).User;
            var topic = this.data.Topics.FindByPredicate(t => t.Title == arbm.TopicTitle);
            Reply reply = new Reply()
            {
                Author = user,
                Content = arbm.Content,
                ImageUrl = arbm.ImageUrl,
                PublishDate = DateTime.Now
            };
            topic.Replies.Add(reply);
            this.data.SaveChanges();
            this.Redirect(response, $"/topics/details?TopicTitle={arbm.TopicTitle}");
            return null;
        }

       

        private bool ValidateTopic(AddTopicBindingModel atbm)
        {
            if (atbm.Title.Length > 30)
            {
                return false;
            }
            if (atbm.Content.Length > 5000)
            {
                return false;
            }
            return true;
        }
    }
}
