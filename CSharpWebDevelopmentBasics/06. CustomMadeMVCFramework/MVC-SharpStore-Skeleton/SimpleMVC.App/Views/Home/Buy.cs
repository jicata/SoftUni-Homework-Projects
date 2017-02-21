namespace SharpStore.Views.Home
{
    using System.IO;
    using MVCFramework.MVC.Interfaces;
    public class Buy : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/buy.html");
        }
    }
}
