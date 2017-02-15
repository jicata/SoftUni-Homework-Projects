namespace SimpleMVC.App.Views.Users
{
    using System.Text;
    using Models;
    using MVC.Interfaces.Generic;
    public class Profile : IRenderable<User>
    {
        public string Render()
        {
            string allUsersUrl = @"http://localhost:8081/users/all";
            StringBuilder pageBuilder = new StringBuilder();
            pageBuilder.AppendLine($"<a href={allUsersUrl}>&larr; Users</a>");
            pageBuilder.AppendLine($"<h2>User: {Model.Username}</h2>");

            pageBuilder.AppendLine("<form action=\"profile\" method=\"POST\">");
            pageBuilder.AppendLine("Title: <input type=\"text\" name=\"Title\" /><br>");
            pageBuilder.AppendLine("Content: <input type=\"text\" name=\"Content\" /><br>");
            pageBuilder.AppendLine($"<input type=\"hidden\" name=\"UserId\" value=\"{Model.Id}\" /><br>");
            pageBuilder.AppendLine("<input type=\"submit\" value=\"Add Note\" /><br>");
            pageBuilder.AppendLine("</form>");
            pageBuilder.AppendLine("<h5>List of notes</h5>");
            pageBuilder.AppendLine("<ul>");
            foreach (var note in Model.Notes)
            {
                pageBuilder.AppendLine($"<li><strong>{note.Title}</strong> - {note.Content}</li>");
            }
            pageBuilder.AppendLine("</ul>");
            return pageBuilder.ToString();

        }

        public User Model { get; set; }
    }
}
