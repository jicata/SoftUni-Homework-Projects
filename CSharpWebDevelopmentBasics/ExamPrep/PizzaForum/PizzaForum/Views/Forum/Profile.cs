namespace PizzaForum.Views.Forum
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using SimpleMVC.Interfaces.Generic;
    using ViewModels;
    public class Profile : IRenderable<HashSet<TopicViewModel>>
    {
        public string Render()
        {
            StringBuilder pageBuilder = new StringBuilder();
            string header = File.ReadAllText("../../content/header.html");
            string nav = File.ReadAllText("../../content/nav-logged.html");
            string content = null;
            string button = null;

            if (this.Model.First().UserLoggedIn)
            {
                content = File.ReadAllText(@"../../content/profile-mine.html")
                    .Replace("##username##", this.Model.First().Author);
                button =
                    @"<td>
    <form method=""POST"" action=""/forum/profile""><input type=""submit"" class=""btn btn-danger"" value=""Delete""/>
<input type=""hidden"" name=""TopicTitle"" value=""##topicTitle##""/></form></td>";
            }
            else
            {
                content = File.ReadAllText(@"../../content/profile-other.html");
            }

            StringBuilder contentBuilder = new StringBuilder();
            foreach (var topicViewModel in this.Model.Skip(1))
            {
                string template = $@"<tr>
				                        <td><a href=""/topics/details?TopicTitle={topicViewModel.Title}"">{topicViewModel.Title}</a></td>
				                        <td><a href=""/categories/topics?CategoryName={topicViewModel.Category}"">{topicViewModel
                    .Category}</a></td>
				                        <td>{topicViewModel.PostedOn}</td>
				                        <td>{topicViewModel.RepliesCount}</td>";

                if (button != null)
                {
                    button = button.Replace("##topicTitle##", topicViewModel.Title);
                    template += button;
                }
                template += "</tr>";
                contentBuilder.Append(template);
            }
            content = content.Replace("##topics##",contentBuilder.ToString());
            string footer = File.ReadAllText("../../content/footer.html");
            pageBuilder.Append(header);
            pageBuilder.Append(nav);
            pageBuilder.Append(content);
            pageBuilder.Append(footer);
            return pageBuilder.ToString();
        }

        public HashSet<TopicViewModel> Model { get; set; }
    }
}
