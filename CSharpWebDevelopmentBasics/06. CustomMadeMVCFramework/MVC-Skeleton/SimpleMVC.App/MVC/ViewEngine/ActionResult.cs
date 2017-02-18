namespace SimpleMVC.App.MVC.ViewEngine
{
    using System;
    using Interfaces;
    public class ActionResult : IActionResult
    {

        public ActionResult(string viewFullyQualifiedName, string location = null)
        {
            this.Action = (IRenderable)
                Activator.CreateInstance(Type.GetType(viewFullyQualifiedName));
            this.Location = location;
        }

        public IRenderable Action { get; set; }

        public string Invoke()
        {
            return this.Action.Render();
        }

        public string Location { get; set; }
    }
}
