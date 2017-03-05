namespace SoftUniStore.Client.Views.Games
{
    using System.IO;
    using System.Text;
    using Constants;
    using SimpleMVC.Interfaces;
    public class Add : IRenderable
    {
        public string Render()
        {
            StringBuilder pageBuilder = new StringBuilder();

            string content = File.ReadAllText("../../content/add-game.html");

            pageBuilder.Append(HtmlFragments.Header);
            pageBuilder.Append(HtmlFragments.MenuLogged);
            pageBuilder.Append(content);
            pageBuilder.Append(HtmlFragments.Footer);

            return pageBuilder.ToString();
        }
    }
}
