namespace PizzaForum.Views.Categories
{
    using System.IO;
    using System.Text;
    using SimpleMVC.Interfaces;
    public class New : IRenderable
    {
        public string Render()
        {
            StringBuilder pageBuilder = new StringBuilder();
            string header = File.ReadAllText("../../content/header.html");
            string nav = File.ReadAllText("../../content/nav-logged.html");
            string content = File.ReadAllText("../../content/admin-category-new.html");
            string footer = File.ReadAllText("../../content/footer.html");
            pageBuilder.Append(header);
            pageBuilder.Append(nav);
            pageBuilder.Append(content);
            pageBuilder.Append(footer);
            return pageBuilder.ToString();
        }
    }
}
