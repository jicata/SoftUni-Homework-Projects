namespace PizzaForum.Views.Forum
{
    using System.IO;
    using System.Text;
    using SimpleMVC.Interfaces;
    public class Login:IRenderable
    {
        public string Render()
        {
            StringBuilder pageBuilder = new StringBuilder();
            string header = File.ReadAllText("../../content/header.html");
            string nav = File.ReadAllText("../../content/nav-not-logged.html");
            string content = File.ReadAllText("../../content/login.html");
            string footer = File.ReadAllText("../../content/footer.html");
            pageBuilder.Append(header);
            pageBuilder.Append(nav);
            pageBuilder.Append(content);
            pageBuilder.Append(footer);
            return pageBuilder.ToString();
        }
    }
}
