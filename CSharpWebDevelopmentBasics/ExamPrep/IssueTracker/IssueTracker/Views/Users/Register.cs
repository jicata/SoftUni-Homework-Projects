namespace IssueTracker.Web.Views.Users
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Models.ViewModels;
    using SimpleMVC.Interfaces.Generic;
    public class Register : IRenderable<HashSet<RegistrationVerificationErrorViewModel>>
    {
        public string Render()
        {
            StringBuilder pageBuilder = new StringBuilder();
            string header = File.ReadAllText("../../content/header.html");
            string menu = File.ReadAllText("../../content/menu.html");
            
            StringBuilder errorBuilder = new StringBuilder();
            foreach (var registrationVerificationErrorViewModel in Model)
            {
                errorBuilder.Append(registrationVerificationErrorViewModel.ToString());
            }

            string coreHtml = File.ReadAllText("../../content/register.html");
            string footer = File.ReadAllText("../../content/footer.html");

            pageBuilder.Append(header);
            pageBuilder.Append(menu);
            pageBuilder.Append(errorBuilder);
            pageBuilder.Append(coreHtml);
            pageBuilder.Append(footer);

            return pageBuilder.ToString();
        }

        public HashSet<RegistrationVerificationErrorViewModel> Model { get; set; }
    }
}
