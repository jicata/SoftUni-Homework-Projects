namespace Shouter.Views.User
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using MVCFramework.MVC.Interfaces.Generic;
    using ViewModels;
    public class Feed : IRenderable<List<ShoutViewModel>>
    {
        public string Render()
        {
            string followersFeedHtml = File.ReadAllText("../../content/myFeed.html");
            StringBuilder pageBuilder = new StringBuilder();
            foreach (var shoutViewModel in this.Model)
            {
                pageBuilder.Append($@"<form action=""/user/feed"" method=""POST"">
                                        <div class=""thumbnail"">
			                               <h4>
                                            <strong>
                                             <p>{shoutViewModel.Author.Username}</p>
                                            <strong> 
                                            <small>{shoutViewModel.PostedForTime}</small></h4>
			                            <p>{shoutViewModel.Content}</p>
                                         <input type=""hidden"" name=""Content"" value=""{shoutViewModel.Content}"">
                                         <input type=""submit"" class=""btn btn-danger"" value=""Delete""/>
                                    </div>
                                      </form>");
            }
            followersFeedHtml = followersFeedHtml.Replace("##feed##", pageBuilder.ToString());
            return followersFeedHtml;
        }

        public List<ShoutViewModel> Model { get; set; }
    }
}
