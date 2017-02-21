namespace SharpStore.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using BindingModels;
    using Data;
    using MVCFramework.MVC.Attributes.Methods;
    using MVCFramework.MVC.Controllers;
    using MVCFramework.MVC.Interfaces;
    using MVCFramework.MVC.Interfaces.Generic;

    public class AdminController : Controller
    {
        private SharpStoreContext context;

        public AdminController()
        {
            this.context = new SharpStoreContext();
        }
        public IActionResult<List<KnifeBindingModel>>  Products()
        {
            var knives = this.context.Knives.ToList();
            List<KnifeBindingModel> bindingKnives = new List<KnifeBindingModel>();
            foreach (var knife in knives)
            {
                var kbm = new KnifeBindingModel()
                {
                    Name = knife.Name,
                    ImageUrl = knife.ImageUrl
                };
                bindingKnives.Add(kbm);
            }
            return this.View(bindingKnives);
        }

        //[HttpPost]
        //public IActionResult<List<KnifeBindingModel>> Products(int id)
        //{

        //    return this.View(new List<Knife>());
        //}
    }
}
