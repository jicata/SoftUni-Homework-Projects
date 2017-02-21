namespace SharpStore.Views.Home
{
    using System.IO;
    using MVCFramework.MVC.Interfaces;

    public class About : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/about-light.html");
        }
    }
}
