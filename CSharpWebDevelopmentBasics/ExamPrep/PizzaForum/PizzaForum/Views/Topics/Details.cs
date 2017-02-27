namespace PizzaForum.Views.Topics
{
    using System.IO;
    using System.Text;
    using SimpleMVC.Interfaces.Generic;
    using ViewModels;
    public class Details : IRenderable<TopicDetailsViewModel>
    {
        public string Render()
        {
            StringBuilder pageBuilder = new StringBuilder();
            string header = File.ReadAllText("../../content/header.html");
            string nav = null;
            string reply = null;
            if (this.Model.UserLogged)
            {
                reply = File.ReadAllText("../../content/topic-details-reply-form.html").Replace("##topicTitle##", this.Model.Title);
            }
            if (this.Model.UserLogged)
            {
                nav = File.ReadAllText("../../content/nav-logged.html");
            }
            else
            {
                nav = File.ReadAllText("../../content/nav-not-logged.html");
            }



            StringBuilder contentBuilder = new StringBuilder();
            string topicTemplate = $@"<div class=""thumbnail"">
	                                    <h4><strong><a href=""/topics/details?TopicTitle={this.Model.Title}"">{this.Model.Title}</a><strong></h4>
	                                    <p><a href=""/forum/profile?ProfileName={this.Model.Author}"">{this.Model.Author}</a> {this.Model.PostedOn}</p>
	                                    <p>{this.Model.Content}</p>
                                    </div>";
            contentBuilder.Append(topicTemplate);
            foreach (var replyViewModel in Model.ReplyViewModels)
            {
                string imgUrl = replyViewModel.ImgUrl != null ? replyViewModel.ImgUrl : "";
                string content = $@"<div class=""thumbnail reply"">
	                                    <h5><strong><a href=""/forum/profile?Username={replyViewModel.Author}"">{replyViewModel.Author}</a><strong> {replyViewModel.Date}</h5>
	                                    <p>{replyViewModel.Content}</p>
                                        <img src=""{imgUrl}"" />
                                    </div>";
                contentBuilder.Append(content);
            }
            

            string footer = File.ReadAllText("../../content/footer.html");
            pageBuilder.Append(header);
            pageBuilder.Append(nav);
            pageBuilder.Append(@"<div class=""container"">");

            pageBuilder.Append(contentBuilder);
            pageBuilder.Append(reply);
            pageBuilder.Append("</div");
            pageBuilder.Append(footer);
            return pageBuilder.ToString();
        }

        public TopicDetailsViewModel Model { get; set; }
    }
}
