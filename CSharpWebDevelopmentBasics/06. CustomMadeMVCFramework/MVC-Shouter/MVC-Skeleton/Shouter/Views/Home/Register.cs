namespace Shouter.Views.Home
{
    using System.IO;
    using MVCFramework.MVC.Interfaces;
    public class Register:IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/register.html");
        }
    }
}
