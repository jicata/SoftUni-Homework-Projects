namespace PizzaForum.Views.Categories
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Models;
    using SimpleMVC.Interfaces.Generic;
    using ViewModels;
    public class All : IRenderable<HashSet<CategoryViewModel>>
    {
        public string Render()
        {
            StringBuilder pageBuilder = new StringBuilder();
            string header = File.ReadAllText("../../content/header.html");
            string nav = File.ReadAllText("../../content/nav-logged.html");
            string content = File.ReadAllText("../../content/admin-categories.html");
            StringBuilder innerBuilder = new StringBuilder();
            foreach (var categoryViewModel in Model)
            {
                string template =
                    $@"<td><a href=""/categories/topics?CategoryName={categoryViewModel.Name}"">{categoryViewModel.Name}</a></td>
				<td><a href=""/categories/edit?CategoryName={categoryViewModel.Name}"" class=""btn btn-primary""/>Edit</a></td>
				<td><a href=""/categories/delete?CategoryName={categoryViewModel.Name}"" class=""btn btn-danger""/>Delete</a></td>";
                innerBuilder.Append(template);

            }
            content = content.Replace("##categories##", innerBuilder.ToString());
            string footer = File.ReadAllText("../../content/footer.html");
            pageBuilder.Append(header);
            pageBuilder.Append(nav);
            pageBuilder.Append(content);
            pageBuilder.Append(footer);
            return pageBuilder.ToString();
        }

        public HashSet<CategoryViewModel> Model { get; set; }
    }
}
