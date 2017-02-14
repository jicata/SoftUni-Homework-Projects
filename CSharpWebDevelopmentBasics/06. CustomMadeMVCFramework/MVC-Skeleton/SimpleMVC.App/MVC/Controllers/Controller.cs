namespace SimpleMVC.App.MVC.Controllers
{
    using System.Runtime.CompilerServices;
    using Interfaces;
    using Interfaces.Generic;
    using ViewEngine;
    using ViewEngine.Generic;

    public abstract class Controller
    {
        protected IActionResult View([CallerMemberName] string caller = "")
        {
            string controllerName = this.GetType()
                .Name
                .Replace(MvcContext.Current.ControllersSuffix, string.Empty);

            string fullyQualifiedName = string.Format("{0}.{1}.{2}.{3}",
                MvcContext.Current.AssemblyName,
                MvcContext.Current.ViewsFolder,
                controllerName,
                caller);

            return new ActionResult(fullyQualifiedName);
        }

        protected IActionResult View(string controller, string action)
        {
            string fullyQualifiedName = string.Format("{0}.{1}.{2}.{3}",
                MvcContext.Current.AssemblyName,
                MvcContext.Current.ViewsFolder,
                controller,
                action);
            return new ActionResult(fullyQualifiedName);
        }

        protected IActionResult<T> View<T>(T model, [CallerMemberName] string caller = "") 
        {
            string controllerName = this.GetType()
               .Name
               .Replace(MvcContext.Current.ControllersSuffix, string.Empty);

            string fullyQualifiedName = string.Format("{0}.{1}.{2}.{3}",
                MvcContext.Current.AssemblyName,
                MvcContext.Current.ViewsFolder,
                controllerName,
                caller);

            return new ActionResult<T>(fullyQualifiedName, model);
        }
        protected IActionResult<T> View<T>(T model, string controller, string action)
        {

            string fullyQualifiedName = string.Format("{0}.{1}.{2}.{3}",
                MvcContext.Current.AssemblyName,
                MvcContext.Current.ViewsFolder,
                controller,
                action);
            return new ActionResult<T>(fullyQualifiedName, model);
        }
    }
}
