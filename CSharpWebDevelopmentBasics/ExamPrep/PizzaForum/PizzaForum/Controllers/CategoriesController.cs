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

    public class CategoriesController : Controller
    {
        private SignInManager signInManager;
        private IPizzaForumData data;

        public CategoriesController()
            :this(new PizzaForumData())
        {

        }

        public CategoriesController(IPizzaForumData data)
        {
            this.data = data;
            this.signInManager = new SignInManager(this.data.Context);
        }

        public IActionResult<HashSet<CategoryViewModel>> All()
        {
            IEnumerable<Category> categories = this.data.Categories.GetAll();
            HashSet<CategoryViewModel> cvms = new HashSet<CategoryViewModel>();

            foreach (var category in categories)
            {
                CategoryViewModel cvm = new CategoryViewModel()
                {
                    Name = category.Name
                };
                cvms.Add(cvm);
            }
            return this.View(cvms);
        }

        public IActionResult<CategoryViewModel> Edit(HttpSession session,HttpResponse response,string categoryName)
        {
            if (!this.signInManager.IsAuthenticated(session))
            {
                //TODO: switch to home
                Redirect(response,"/forum/login");
            }
            Category cat = this.data.Categories.FindByPredicate(c => c.Name == categoryName);
            if (cat != null)
            {
                CategoryViewModel cvm = new CategoryViewModel()
                {
                    Name = cat.Name
                };
                return this.View(cvm);
            }
            Redirect(response,"/categories/all");
            return null;
        }
        [HttpPost]
        public IActionResult<CategoryViewModel> Edit(HttpSession session,HttpResponse response, CategoryEditBindingModel cebm)
        {
            if (!this.signInManager.IsAuthenticated(session))
            {
                //TODO: switch to home
                Redirect(response, "/forum/login");
            }
            Category cat = this.data.Categories.FindByPredicate(c => c.Name == cebm.OldCatName);
            cat.Name = cebm.NewCatName;
            this.data.SaveChanges();
            this.Redirect(response,"/categories/all");
            return null;
        }

        public IActionResult New(HttpSession session, HttpResponse response)
        {
            if (!this.signInManager.IsAuthenticated(session))
            {
                //TODO: switch to home
                Redirect(response, "/forum/login");
            }
            return this.View();
        }

        [HttpPost]
        public IActionResult New(HttpSession session, HttpResponse response,CategoryBindingModel cbm)
        {
            if (!this.signInManager.IsAuthenticated(session))
            {
                //TODO: switch to home
                Redirect(response, "/forum/login");
            }
            Category cat = new Category()
            {
                Name = cbm.Name
            };
            try
            {
                this.data.Categories.Insert(cat);
                this.data.SaveChanges();
            }
            catch (Exception e)
            {
                return this.View();
            }
            Redirect(response, "/categories/all");
            return null;
        }

        public IActionResult<HashSet<TopicViewModel>> Topics(string categoryName)
        {
            var topics = this.data.Categories.FindByPredicate(c => c.Name == categoryName).Topics;
            HashSet<TopicViewModel> tvms = new HashSet<TopicViewModel>();

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
        public IActionResult Delete(HttpResponse response, string categoryName)
        {
            var category = this.data.Categories.FindByPredicate(c => c.Name == categoryName);
            this.data.Categories.Delete(category);
            this.data.SaveChanges();
            Redirect(response, "/categories/all");
            return null;
        }
    }
}
