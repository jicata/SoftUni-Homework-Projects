namespace IssueTracker.Models.ViewModels
{
    public class IssueViewModel
    {
        public LoggedInUserViewModel LoggedInUserViewModel { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public string Priority { get; set; }

        public string CreatedOn { get; set; }

        public string Author { get; set; }

        public override string ToString()
        {
            string template = $@"<tr>
					<td>{this.Id}</td>
					<td>{this.Name}</td>
					<td>{this.Status}</td>
					<td>{this.Priority}</td>
					<td>{this.CreatedOn}</td>
					<td>{this.Author}</td>";

            if (this.LoggedInUserViewModel.IsAdmin || this.LoggedInUserViewModel.Username == this.Author)
            {
                string buttonTemplate = $@"<td>
						                      <a href=""/issues/edit?id={this.Id}"" class=""btn mini btn-primary"">Edit</a>
					                        </td>
					                        <td>
						                       <a href=""/issues/delete?id={this.Id}"" class=""confirm-delete mini btn btn-danger"">Delete</a>
					                        </td>";
                template += buttonTemplate;
            }
            template += "</tr>";
            return template;
        }
    }
}
