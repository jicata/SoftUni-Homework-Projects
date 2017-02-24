namespace Shouter.Views.User
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using MVCFramework.MVC.Interfaces.Generic;
    using ViewModels;

    public class Notifications : IRenderable<List<NotificationViewModel>>
    {
        public string Render()
        {
            string notificationsHtml = File.ReadAllText("../../content/notifications.html");
            StringBuilder pageBuilder = new StringBuilder();
            foreach (var notificationViewModel in Model)
            {
                pageBuilder.Append(
                    $@"<li><h4><strong><a href=""/followers/profile?id={notificationViewModel.UserId}"">{notificationViewModel
                        .Username}</a></strong> posted a shout</h4></li>");
            }
            notificationsHtml = notificationsHtml.Replace("##notifications##", pageBuilder.ToString());
            return notificationsHtml;
        }

        public List<NotificationViewModel> Model { get; set; }
    }
}
