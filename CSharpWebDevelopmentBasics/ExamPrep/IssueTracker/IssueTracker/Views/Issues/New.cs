namespace IssueTracker.Web.Views.Issues
{
    using System.IO;
    using System.Text;
    using Models.ViewModels;
    using SimpleMVC.Interfaces.Generic;
    public class New : IRenderable<LoggedInUserViewModel>
    {
        public string Render()
        {
            StringBuilder pageBuilder = new StringBuilder();

            string header = File.ReadAllText("../../content/header.html");
            string menu = File.ReadAllText("../../content/menu-logged.html").Replace("##Username##", this.Model.Username);

            string coreHtml = File.ReadAllText("../../content/issue-new.html");
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
