namespace MVCFramework.MVC.ViewEngine
{
    using System;
    using Interfaces;

    public class ActionResult : IActionResult
    {
        public ActionResult(string viewFullQualifedName)
        {
            this.Action = (IRenderable)Activator
                .CreateInstance(MvcContext.Current.CurrentAssembly.GetType(viewFullQualifedName));
        }

        public IRenderable Action { get; set; }

        public string Invoke()
        {
            return this.Action.Render();
        }
    }
}
