namespace PizzaForum.Views.Categories
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using SimpleMVC.Interfaces.Generic;
    using ViewModels;
    public class Topics : IRenderable<HashSet<TopicViewModel>>
    {
        public string Render()
        {
            StringBuilder pageBuilder = new StringBuilder();
            string header = File.ReadAllText("../../content/header.html");
            string nav = File.ReadAllText("../../content/nav-logged.html");

           
            StringBuilder contentBuilder = new StringBuilder();

            foreach (var topicViewModel in this.Model)
            {
                string content = $@"<div class=""thumbnail"">
	                                <h4><strong><a href=""/topics/details?TopicTitle={topicViewModel.Title}"">{topicViewModel.Title}</a><strong> 
                                        <small><a href=""/categories/details?CategoryName={topicViewModel.Category}"">{topicViewModel.Category}</a></small></h4>
	                                <p><a href=""/forum/profile?ProfileName={topicViewModel.Author}"">{topicViewModel.Author}</a> 
                                        | Replies: {topicViewModel.RepliesCount} | {topicViewModel.PostedOn}</p>
                               </div>";
                contentBuilder.Append(content);
            }


            string footer = File.ReadAllText("../../content/footer.html");
            pageBuilder.Append(header);
            pageBuilder.Append(nav);
            pageBuilder.Append(@"<div class=""container"">");
            pageBuilder.Append(contentBuilder);
            pageBuilder.Append("</div");
            pageBuilder.Append(footer);
            return pageBuilder.ToString();
        }

        public HashSet<TopicViewModel> Model { get; set; }
    }
}
