namespace SharpStore.Controllers
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Net;
    using BindingModels;
    using Data;
    using MVCFramework.MVC.Attributes.Methods;
    using MVCFramework.MVC.Controllers;
    using MVCFramework.MVC.Interfaces;
    using MVCFramework.MVC.Interfaces.Generic;
    using Security;
    using SimpleHttpServer.Models;
    using ViewModels;

    public class AdminController : Controller
    {
        private SharpStoreContext context;
        private SignInManager signInManager;

        public AdminController()
        {
            this.context = new SharpStoreContext();
            this.signInManager = new SignInManager(this.context);
        }
        [HttpGet]
        public IActionResult<List<KnifeViewModel>> Products(HttpSession session, HttpResponse response)
        {
            if (!this.signInManager.IsAuthenticated(session))
            {
                Redirect(response,"/home/login");
                return null;
            }
            var knives = this.context.Knives.ToList();
            List<KnifeViewModel> bindingKnives = new List<KnifeViewModel>();
            foreach (var knife in knives)
            {
                var kbm = new KnifeViewModel()
                {
                    Name = knife.Name,
                    ImageUrl = knife.ImageUrl,
                    Price = knife.Price
                };
                bindingKnives.Add(kbm);
            }
            return this.View(bindingKnives);
        }
        [HttpPost]
        public IActionResult Products(HttpResponse response, KnifeBindingModel kbm)
        {
            var knife = this.context.Knives.FirstOrDefault(k => k.Name == kbm.Name);
            this.context.Knives.Remove(knife);
            this.context.SaveChanges();
            Redirect(response, "/admin/products");
            return null;

        }


        [HttpGet]
        public IActionResult<KnifeViewModel> Edit(HttpResponse response, string knifeUrl)
        {
            knifeUrl = WebUtility.UrlDecode(knifeUrl);
            var knife = this.context.Knives.FirstOrDefault(k => k.ImageUrl == knifeUrl);
            if (knife != null)
            {
                var kbm = new KnifeViewModel()
                {
                    Name = knife.Name,
                    ImageUrl = knifeUrl,
                    Price = knife.Price
                };
                return this.View(kbm);
            }
            Redirect(response, "/admin/products");
            return null;
        }

        [HttpPost]
        public IActionResult Edit(HttpResponse response, KnifeViewModel knifebm)
        {
            var knife = this.context.Knives.FirstOrDefault(k => k.Name == knifebm.Name);
            knife.ImageUrl = WebUtility.UrlDecode(knifebm.ImageUrl);
            knife.Price = knifebm.Price;
            this.context.Knives.AddOrUpdate(knife);
            this.context.SaveChanges();
            Redirect(response, "/admin/products");
            return null;

        }

        [HttpGet]
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Add(KnifeAddBindingModel kbm, HttpResponse response)
        {
            var knife = new Knife()
            {
                ImageUrl = WebUtility.UrlDecode(kbm.ImageUrl),
                Name = kbm.Name,
                Price = kbm.Price
            };
            this.context.Knives.Add(knife);
            this.context.SaveChanges();
            Redirect(response,"/admin/products");
            return null;
        }

    }
}
