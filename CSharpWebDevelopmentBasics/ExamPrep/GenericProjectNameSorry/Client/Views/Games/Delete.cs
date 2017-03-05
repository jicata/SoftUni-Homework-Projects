namespace SoftUniStore.Client.Views.Games
{
    using System.IO;
    using System.Text;
    using Constants;
    using Models.ViewModels;
    using SimpleMVC.Interfaces.Generic;
    public class Delete : IRenderable<DeleteGameViewModel>
    {
        public string Render()
        {
            StringBuilder pageBuilder = new StringBuilder();

            string content = File.ReadAllText("../../content/delete-game.html")
                .Replace("##id##", Model.Id.ToString())
                .Replace("##name##", Model.Title);

            pageBuilder.Append(HtmlFragments.Header);
            pageBuilder.Append(HtmlFragments.MenuLogged);
            pageBuilder.Append(content);
            pageBuilder.Append(HtmlFragments.Footer);

            return pageBuilder.ToString();
        }

        public DeleteGameViewModel Model { get; set; }
    }
}
