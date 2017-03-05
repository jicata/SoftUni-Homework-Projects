namespace SoftUniStore.Client.Views.Home
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Constants;
    using Models.ViewModels;
    using SimpleMVC.Interfaces.Generic;
    public class Index : IRenderable<GameViewModelsCollection>
    {
        public string Render()
        {
            StringBuilder pageBuilder = new StringBuilder();

            string menu = this.Model.IsLogged ? HtmlFragments.MenuLogged : HtmlFragments.MenuNotLogged;

            string content = File.ReadAllText("../../content/home.html");
            StringBuilder innerHtml = new StringBuilder();
            innerHtml.Append(@"<div class=""card-group"">");
            for (int i = 0; i < this.Model.Games.Count; i++)
            {
                innerHtml.Append(this.Model.Games[i]);
                if ((i+1) % 3 == 0)
                {
                    innerHtml.Append(@"</div><div class=""card-group"">");
                }
            }
            if (this.Model.Games.Count % 3 != 0)
            {
                innerHtml.Append(@"</div>");
            }
            content = content.Replace("##games##", innerHtml.ToString());
            pageBuilder.Append(HtmlFragments.Header);
            pageBuilder.Append(menu);
            pageBuilder.Append(content);
            pageBuilder.Append(HtmlFragments.Footer);

            return pageBuilder.ToString();
        }

        public GameViewModelsCollection Model { get; set; }

        
    }
}
