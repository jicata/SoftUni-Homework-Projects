namespace SoftUniStore.Client.Views.Games
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Constants;
    using Models.ViewModels;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;

    public class All : IRenderable<HashSet<AdminGameViewModel>>
    {
        public string Render()
        {
            StringBuilder pageBuilder = new StringBuilder();

            string content = File.ReadAllText("../../content/admin-games.html");
            StringBuilder innerHtml = new StringBuilder();
            foreach (var adminGameViewModel in this.Model)
            {
                innerHtml.Append(adminGameViewModel);
            }
            content = content.Replace("##games##", innerHtml.ToString());
            pageBuilder.Append(HtmlFragments.Header);
            pageBuilder.Append(HtmlFragments.MenuLogged);
            pageBuilder.Append(content);
            pageBuilder.Append(HtmlFragments.Footer);

            return pageBuilder.ToString();
        }

        public HashSet<AdminGameViewModel> Model { get; set; }
    }
}
