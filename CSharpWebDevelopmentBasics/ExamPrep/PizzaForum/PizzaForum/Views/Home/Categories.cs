namespace PizzaForum.Views.Home
{
    using System.Collections.Generic;
    using System.IO;
    using System.Security.Policy;
    using System.Text;
    using SimpleMVC.Interfaces.Generic;
    using ViewModels;
    public class Categories : IRenderable<HashSet<CategoryViewModel>>
    {
        public string Render()
         {

            StringBuilder pageBuilder = new StringBuilder();
            string header = File.ReadAllText("../../content/header.html");
            string nav = File.ReadAllText("../../content/nav-logged.html");
             string content = @"<div class=""container""><div class=""row""><ul>";
             foreach (var categoryViewModel in this.Model)
             {
                 content +=
                     $@"<li><h4><a href=""/categories/topics?CategoryName={categoryViewModel.Name}"">{categoryViewModel.Name}</a></h4></li>";
             }
             content += "</ul></div></div>";
            string footer = File.ReadAllText("../../content/footer.html");
            pageBuilder.Append(header);
            pageBuilder.Append(nav);
            pageBuilder.Append(content);
            pageBuilder.Append(footer);
            return pageBuilder.ToString();
        }

        public HashSet<CategoryViewModel> Model { get; set; }
    }
}
