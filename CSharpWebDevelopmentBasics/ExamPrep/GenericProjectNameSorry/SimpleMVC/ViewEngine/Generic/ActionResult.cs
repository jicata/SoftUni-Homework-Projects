using System;
using SimpleMVC.Interfaces.Generic;

namespace SimpleMVC.ViewEngine.Generic
{
    public class ActionResult<T> : IActionResult<T>
    {
        public ActionResult(string viewFullQualifiedName, T model)
        {
            this.Action =
                (IRenderable<T>)Activator
                .CreateInstance(MvcContext.Current.ApplicationAssembly.GetType(viewFullQualifiedName));

            this.Action.Model = model;
        }

        public IRenderable<T> Action { get; set; }

        public string Invoke()
        {
            return this.Action.Render();
        }
    }
}
