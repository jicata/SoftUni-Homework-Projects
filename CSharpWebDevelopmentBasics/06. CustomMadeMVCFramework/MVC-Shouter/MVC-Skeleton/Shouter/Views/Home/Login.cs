namespace Shouter.Views.Home
{
    using System.IO;
    using MVCFramework.MVC.Interfaces;
    public class Login : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/login.html");
        }
    }
}
