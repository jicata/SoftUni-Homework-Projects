namespace PizzaForum.Views.Topics
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using SimpleMVC.Interfaces.Generic;
    using ViewModels;
    public class New : IRenderable<HashSet<CategoryViewModel>>
    {
        public string Render()
        {
            StringBuilder pageBuilder = new StringBuilder();
            string header = File.ReadAllText("../../content/header.html");
            string nav = File.ReadAllText("../../content/nav-logged.html");
            string content = File.ReadAllText("../../content/topic-new.html");
            string footer = File.ReadAllText("../../content/footer.html");
            StringBuilder contentBuilder = new StringBuilder();
            foreach (var categoryViewModel in this.Model)
            {
                string template = $@"<option value=""{categoryViewModel.Name}"">{categoryViewModel.Name}</option>";
                contentBuilder.Append(template);
            }
            content = content.Replace("##categories##", contentBuilder.ToString());
            pageBuilder.Append(header);
            pageBuilder.Append(nav);
            pageBuilder.Append(content);
            pageBuilder.Append(footer);
            return pageBuilder.ToString();
        }

        public HashSet<CategoryViewModel> Model { get; set; }
    }
}
