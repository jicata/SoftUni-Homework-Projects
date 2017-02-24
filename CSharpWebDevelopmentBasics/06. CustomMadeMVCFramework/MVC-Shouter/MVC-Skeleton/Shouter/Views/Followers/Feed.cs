namespace Shouter.Views.Followers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using MVCFramework.MVC.Interfaces;
    using MVCFramework.MVC.Interfaces.Generic;
    using ViewModels;

    public class Feed : IRenderable<List<ShoutViewModel>>
    {
        public string Render()
        {
            string followersFeedHtml = File.ReadAllText("../../content/followersFeed.html");
            StringBuilder pageBuilder = new StringBuilder();
            foreach (var shoutViewModel in this.Model)
            {
                pageBuilder.Append($@"<div class=""thumbnail"">
			                               <h4>
                                            <strong>
                                             <a href=""/followers/profile?id={shoutViewModel.Author.Id}"">{shoutViewModel.Author.Username}</a>
                                            <strong> 
                                            <small>{shoutViewModel.PostedForTime}</small></h4>
			                            <p>{shoutViewModel.Content}</p>
		                            </div>");
            }
            followersFeedHtml = followersFeedHtml.Replace("##feed##", pageBuilder.ToString());
            return followersFeedHtml;
        }

        public List<ShoutViewModel> Model { get; set; }
    }
}
