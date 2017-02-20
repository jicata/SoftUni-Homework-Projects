using SimpleHttpServer;

namespace SimpleMVC.App
{
    using MVCFramework.MVC;

    class AppStart
    {
        static void Main(string[] args)
        {
            HttpServer server = new HttpServer(8081, RouteTable.Routes);
            MvcEngine.Run(server, "SimpleMVC.App");
        }
    }
}
