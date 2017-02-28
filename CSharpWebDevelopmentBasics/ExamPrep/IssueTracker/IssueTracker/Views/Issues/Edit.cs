namespace IssueTracker.Web.Views.Issues
{
    using System.IO;
    using System.Text;
    using Models.ViewModels;
    using SimpleMVC.Interfaces.Generic;
    public class Edit:IRenderable<EditIssueViewModel>
    {
        public string Render()
        {
            StringBuilder pageBuilder = new StringBuilder();

            string header = File.ReadAllText("../../content/header.html");
            string menu = File.ReadAllText("../../content/menu-logged.html").Replace("##Username##", this.Model.LoggedInUserViewModel.Username);

            string coreHtml = File.ReadAllText("../../content/issue-edit.html").Replace("##id##", this.Model.Id.ToString());
            string footer = File.ReadAllText("../../content/footer.html");

            pageBuilder.Append(header);
            pageBuilder.Append(menu);
            pageBuilder.Append(coreHtml);
            pageBuilder.Append(footer);

            return pageBuilder.ToString();
        }

        public EditIssueViewModel Model { get; set; }
    }
}
