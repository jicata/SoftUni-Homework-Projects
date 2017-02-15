namespace SimpleMVC.App.Views.Home
{
    using System.Text;
    using MVC.Interfaces;
    public class Index : IRenderable
    {
        public string Render()
        {
            string allUsersUrl = @"http://localhost:8081/users/all";
            string registerUrl = @"http://localhost:8081/users/register";
            StringBuilder pagebuilder = new StringBuilder();
            pagebuilder.AppendLine("<h3>Notes app</h3>");
            pagebuilder.AppendLine($@"<a href=""{allUsersUrl}"">All Users</a></br><a href=""{registerUrl}"">Register</a>");
            return pagebuilder.ToString();
        }
    }
}
