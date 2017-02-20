namespace MVCFramework.MVC
{
    using System;
    using System.Reflection;
    using SimpleHttpServer;

    public static class MvcEngine
    {
        public static void Run(HttpServer server, string currentAssembly)
        {
            RegisterAssemblyName(currentAssembly);
            RegisterControllers();
            RegisterViews();
            RegisterModels();

            try
            {
                server.Listen();
            }
            catch (Exception e)
            {
                //Log errors
                Console.WriteLine(e.Message);
            }
        }

        private static void RegisterAssemblyName(string currentAssembly)
        {
            MvcContext.Current.AssemblyName = currentAssembly;

        }

        private static void RegisterControllers()
        {
            MvcContext.Current.ControllersFolder = $"Controllers";
            MvcContext.Current.ControllersSuffix = "Controller";
        }

        private static void RegisterViews()
        {
            MvcContext.Current.ViewsFolder = "Views";
        }

        private static void RegisterModels()
        {
            MvcContext.Current.ModelsFolder = "Models";
        }
    }
}
