namespace Shouter
{
    using MVCFramework.MVC;
    using SimpleHttpServer;

    class AppStart
    {
        static void Main()
        {
            HttpServer server = new HttpServer(8081, RoutesTable.Routes);
            MvcEngine.Run(server, "Shouter");
        }
    }
}
