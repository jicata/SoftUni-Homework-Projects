namespace SoftUniStore.Client.Views.Home
{
    using System.IO;
    using System.Text;
    using Constants;
    using Models.ViewModels;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;

    public class Details : IRenderable<GameDetailsViewModel>
    {
        public string Render()
        {
            StringBuilder pageBuilder = new StringBuilder();
            string menu = this.Model.IsUserLogged ? HtmlFragments.MenuLogged : HtmlFragments.MenuNotLogged;

            string content = File.ReadAllText("../../content/game-details.html")
                .Replace("##game##", this.Model.ToString());

            pageBuilder.Append(HtmlFragments.Header);
            pageBuilder.Append(menu);
            pageBuilder.Append(content);
            pageBuilder.Append(HtmlFragments.Footer);

            return pageBuilder.ToString();
        }

        public GameDetailsViewModel Model { get; set; }
    }
}
