namespace Shouter.Views.Home
{
    using System.IO;
    using MVCFramework.MVC.Interfaces;
    public class FollowersFeed : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/followersFeed.html");
        }
    }
}
