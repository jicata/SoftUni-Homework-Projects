namespace SoftUniStore.Client.Views.Games
{
    using System.IO;
    using System.Text;
    using Constants;
    using Models.ViewModels;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;

    public class Edit : IRenderable<EditGameViewModel>
    {
        public string Render()
        {

            StringBuilder pageBuilder = new StringBuilder();

            string content = File.ReadAllText("../../content/edit-game.html")
                .Replace("##id##", this.Model.Id)
                .Replace("##title##", this.Model.Title)
                .Replace("##description##", this.Model.Description)
                .Replace("##imageUrl##", this.Model.ImageUrl)
                .Replace("##price##", this.Model.Price.ToString())
                .Replace("##size##", this.Model.Size.ToString())
                .Replace("##trailer##", this.Model.Trailer);

            pageBuilder.Append(HtmlFragments.Header);
            pageBuilder.Append(HtmlFragments.MenuLogged);
            pageBuilder.Append(content);
            pageBuilder.Append(HtmlFragments.Footer);

            return pageBuilder.ToString();
        }

        public EditGameViewModel Model { get; set; }
    }
}
