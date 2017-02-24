namespace Shouter.Views.User
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using MVCFramework.MVC.Interfaces.Generic;
    using ViewModels;
    public class Followers : IRenderable<List<UserViewModel>>
    {
        public string Render()
        {
            string followersHtml = File.ReadAllText("../../content/following.html");
            StringBuilder pageBuilder = new StringBuilder();
            foreach (var userViewModel in Model)
            {
                pageBuilder.Append(
                    $@"<li><h4><strong><a href=""/followers/profile?id={userViewModel.Id}"">{userViewModel.Username}</a></strong> </h4></li>");
            }
            followersHtml = followersHtml.Replace("##followers##", pageBuilder.ToString());
            return followersHtml;
        }

        public List<UserViewModel> Model { get; set; }
    }
}
