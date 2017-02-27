using System;
using System.Reflection;
using SimpleHttpServer;

namespace SimpleMVC
{
    public static class MvcEngine
    {
        public static void Run(HttpServer server, string applicationAssemblyName)
        {
            RegisterAssemblyName(applicationAssemblyName);
            LoadApplicationAssembly(applicationAssemblyName);
            RegisterControllers();
            RegisterViews();
            RegisterModels();

            try
            {
                server.Listen();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void LoadApplicationAssembly(string applicationAssemblyName)
        {
            MvcContext.Current.ApplicationAssembly = Assembly.Load(applicationAssemblyName);
        }

        private static void RegisterAssemblyName(string applicationAssemblyName)
        {
            MvcContext.Current.AssemblyName = applicationAssemblyName;
        }

        private static void RegisterControllers()
        {
            MvcContext.Current.ControllersFolder = "Controllers";
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
