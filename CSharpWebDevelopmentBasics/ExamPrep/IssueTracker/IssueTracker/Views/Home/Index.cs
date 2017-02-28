namespace IssueTracker.Web.Views.Home
{
    using System.IO;
    using System.Text;
    using Models.ViewModels;
    using SimpleMVC.Interfaces.Generic;

    public class Index : IRenderable<LoggedInUserViewModel>
    {
        public string Render()
        {
            StringBuilder pageBuilder = new StringBuilder();

            string header = File.ReadAllText("../../content/header.html");
            string menu = null;
            if (this.Model.Username != null)
            {
                menu = File.ReadAllText("../../content/menu-logged.html").Replace("##Username##", this.Model.Username);
            }
            else
            {
                menu = File.ReadAllText("../../content/menu.html");
            }

            string coreHtml = File.ReadAllText("../../content/home.html");
            string footer = File.ReadAllText("../../content/footer.html");

            pageBuilder.Append(header);
            pageBuilder.Append(menu);
            pageBuilder.Append(coreHtml);
            pageBuilder.Append(footer);

            return pageBuilder.ToString();
        }

        public LoggedInUserViewModel Model { get; set; }
    }
}
