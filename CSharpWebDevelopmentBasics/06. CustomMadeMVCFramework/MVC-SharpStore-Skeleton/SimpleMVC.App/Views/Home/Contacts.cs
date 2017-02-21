namespace SharpStore.Views.Home
{
    using System.IO;
    using MVCFramework.MVC.Interfaces;
    public class Contacts:IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/contacts-dark.html");
        }
    }
}
