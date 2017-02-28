namespace IssueTracker.Web.Views.Issues
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security.Policy;
    using System.Text;
    using Models.ViewModels;
    using SimpleMVC.Interfaces.Generic;

    public class All : IRenderable<HashSet<IssueViewModel>>
    {
        public string Render()
        {
            StringBuilder pageBuilder = new StringBuilder();

            string header = File.ReadAllText("../../content/header.html");
            string menu = File.ReadAllText("../../content/menu-logged.html").Replace("##Username##", this.Model.First().LoggedInUserViewModel.Username);

            string coreHtml = File.ReadAllText("../../content/issues.html");

            StringBuilder corebuilder = new StringBuilder();
            foreach (var issueViewModel in this.Model.Skip(1))
            {
                corebuilder.Append(issueViewModel);
            }
            coreHtml = coreHtml.Replace("##issues##", corebuilder.ToString());
            string footer = File.ReadAllText("../../content/footer.html");

            pageBuilder.Append(header);
            pageBuilder.Append(menu);
            pageBuilder.Append(coreHtml);
            pageBuilder.Append(footer);

            return pageBuilder.ToString();
        }

        public HashSet<IssueViewModel> Model { get; set; }
    }
}
