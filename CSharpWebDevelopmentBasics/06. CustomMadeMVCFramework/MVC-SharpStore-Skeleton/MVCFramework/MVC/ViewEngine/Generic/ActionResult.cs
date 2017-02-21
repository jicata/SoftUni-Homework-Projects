namespace MVCFramework.MVC.ViewEngine.Generic
{
    using System;
    using Interfaces.Generic;

    public class ActionResult<T> : IActionResult<T>
    {
        public ActionResult(string viewFullQualifiedName, T model)
        {
            this.Action =
                (IRenderable<T>)Activator
                .CreateInstance(MvcContext.Current.CurrentAssembly.GetType(viewFullQualifiedName));

            this.Action.Model = model;
        }

        public IRenderable<T> Action { get; set; }

        public string Invoke()
        {
            return this.Action.Render();
        }
    }
}
