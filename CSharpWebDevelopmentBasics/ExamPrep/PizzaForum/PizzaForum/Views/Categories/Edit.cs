namespace PizzaForum.Views.Categories
{
    using System.IO;
    using System.Text;
    using SimpleMVC.Interfaces.Generic;
    using ViewModels;
    public class Edit : IRenderable<CategoryViewModel>
    {
        public string Render()
        {
            StringBuilder pageBuilder = new StringBuilder();
            string header = File.ReadAllText("../../content/header.html");
            string nav = File.ReadAllText("../../content/nav-logged.html");
            string content = File.ReadAllText("../../content/admin-category-edit.html");

            content = content.Replace("##tinyplaceholder##",this.Model.Name);
            string footer = File.ReadAllText("../../content/footer.html");
            pageBuilder.Append(header);
            pageBuilder.Append(nav);
            pageBuilder.Append(content);
            pageBuilder.Append(footer);
            return pageBuilder.ToString();
        }

        public CategoryViewModel Model { get; set; }
    }
}
