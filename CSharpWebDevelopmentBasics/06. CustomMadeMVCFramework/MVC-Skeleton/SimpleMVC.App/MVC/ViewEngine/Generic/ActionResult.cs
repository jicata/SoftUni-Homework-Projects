namespace SimpleMVC.App.MVC.ViewEngine.Generic
{
    using System;
    using Interfaces.Generic;
    public class ActionResult<T>: IActionResult<T>
    {
        public ActionResult(string fullyQualifiedViewName, T model, string location = null)
        {
            
            this.Action =(IRenderable<T>)
                Activator.CreateInstance(Type.GetType(fullyQualifiedViewName));

            this.Action.Model = model;
            this.Location = location;

        }

        public IRenderable<T> Action { get; set; }

        public string Invoke()
        {
            return this.Action.Render();
        }

        public string Location { get; set; }
    }
}
