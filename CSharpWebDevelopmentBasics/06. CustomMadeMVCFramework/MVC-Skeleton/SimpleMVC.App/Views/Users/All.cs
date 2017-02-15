namespace SimpleMVC.App.Views.Users
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Web;
    using Models;
    using MVC.Interfaces.Generic;
    public class All : IRenderable<List<User>>
    {
        public string Render()
        {
            string homeUrl = @"http://localhost:8081/home/index";
            StringBuilder htmlBuilder = new StringBuilder();
            htmlBuilder.AppendLine($"<a href={homeUrl}>&larr; Home</a>");
            htmlBuilder.AppendLine("<h3>All users</h3>");
            htmlBuilder.AppendLine("<ul>");
            foreach (User user in Model)
            {
                string encoded = "http://localhost:8081/users/profile?id=" + $"{user.Id}";
                htmlBuilder.AppendLine($@"<li><a href=""{encoded}"">{user.Username}</li>");
            }
            htmlBuilder.AppendLine("</ul>");
            return htmlBuilder.ToString();

        }

        public List<User> Model { get; set; }
    }
}
