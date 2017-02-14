namespace SimpleMVC.App.MVC.ViewEngine
{
    using System;
    using Interfaces;
    public class ActionResult : IActionResult
    {

        public ActionResult(string viewFullyQualifiedName)
        {
            this.Action = (IRenderable)
                Activator.CreateInstance(Type.GetType(viewFullyQualifiedName));
        }

        public IRenderable Action { get; set; }

        public string Invoke()
        {
            return this.Action.Render();
        }
    }
}
