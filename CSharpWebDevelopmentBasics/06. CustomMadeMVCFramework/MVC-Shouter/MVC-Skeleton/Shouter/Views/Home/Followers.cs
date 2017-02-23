namespace Shouter.Views.Home
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using MVCFramework.MVC.Interfaces;
    using MVCFramework.MVC.Interfaces.Generic;
    using ViewModels;
    public class Followers : IRenderable<List<FollowerViewModel>>
    {
        public string Render()
        {
            string followersHtml =  File.ReadAllText("../../content/followers.html");
            StringBuilder pageBuilder = new StringBuilder();
            foreach (var followerViewModel in Model)
            {
                string template = $@"  <li class=""list-group-item"">
                <form class=""form-group"" action=""/home/followers"" method=""POST"">
                        <h4>
                        <input type=""hidden"" name=""Id"" value=""{followerViewModel.Id}""</input>
                            <strong><a class=""col-md-8""href=""/user/profile?id={followerViewModel.Id}"">{followerViewModel.Username}</a></strong>
                        <input type=""submit"" class=""btn btn-{followerViewModel.FollowStatus}"" value=""{followerViewModel.FollowOption}""/>
                        </h4>
                </form>
            </li>";
                pageBuilder.Append(template);
            }
            followersHtml = followersHtml.Replace("##following##", pageBuilder.ToString());
            return followersHtml;

        }

        public List<FollowerViewModel> Model { get; set; }
    }
}
