namespace SimpleMVC.App.MVC.ViewEngine.Generic
{
    using System;
    using System.Threading;
    using Interfaces.Generic;
    public class ActionResult<T>: IActionResult<T>
    {
        public ActionResult(string fullyQualifiedViewName, T model)
        {
            this.Action =(IRenderable<T>)
                Activator.CreateInstance(Type.GetType(fullyQualifiedViewName));

            this.Action.Model = model;
        }
        
        public IRenderable<T> Action { get; set; }

        public string Invoke()
        {
            return this.Action.Render();
        }

    }
}
