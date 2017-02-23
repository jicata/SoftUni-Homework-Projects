namespace Shouter.Views.Home
{
    using System.IO;
    using MVCFramework.MVC.Interfaces;
    public class Followers : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/followers.html");    
        }
    }
}
