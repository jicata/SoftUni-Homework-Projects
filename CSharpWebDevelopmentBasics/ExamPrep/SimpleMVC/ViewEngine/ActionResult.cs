using System;
using SimpleMVC.Interfaces;

namespace SimpleMVC.ViewEngine
{
    public class ActionResult : IActionResult
    {
        public ActionResult(string viewFullQualifedName)
        {
            this.Action = (IRenderable)Activator
                .CreateInstance(MvcContext.Current.ApplicationAssembly.GetType(viewFullQualifedName));
        }

        public IRenderable Action { get; set; }

        public string Invoke()
        {
            return this.Action.Render();
        }
    }
}
