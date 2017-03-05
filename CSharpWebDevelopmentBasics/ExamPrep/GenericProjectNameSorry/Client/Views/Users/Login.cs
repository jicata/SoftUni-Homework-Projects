namespace SoftUniStore.Client.Views.Users
{
    using System.IO;
    using System.Text;
    using Constants;
    using SimpleMVC.Interfaces;

    public class Login : IRenderable
    {
        public string Render()
        {
            StringBuilder pageBuilder = new StringBuilder();

            string content = File.ReadAllText("../../content/login.html");

            pageBuilder.Append(HtmlFragments.Header);
            pageBuilder.Append(HtmlFragments.MenuNotLogged);
            pageBuilder.Append(content);
            pageBuilder.Append(HtmlFragments.Footer);

            return pageBuilder.ToString();
        }
    }
}
