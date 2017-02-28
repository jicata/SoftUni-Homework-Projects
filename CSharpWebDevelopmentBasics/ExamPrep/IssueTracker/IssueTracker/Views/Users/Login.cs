namespace IssueTracker.Web.Views.Users
{
    using System.IO;
    using System.Text;
    using SimpleMVC.Interfaces;
    public class Login : IRenderable
    {
        public string Render()
        {
            StringBuilder pageBuilder = new StringBuilder();

            string header = File.ReadAllText("../../content/header.html");
            string menu = File.ReadAllText("../../content/menu.html");
            string coreHtml = File.ReadAllText("../../content/login.html");
            string footer = File.ReadAllText("../../content/footer.html");

            pageBuilder.Append(header);
            pageBuilder.Append(menu);
            pageBuilder.Append(coreHtml);
            pageBuilder.Append(footer);

            return pageBuilder.ToString();
        }
    }
}
