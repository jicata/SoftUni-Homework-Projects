namespace SimpleMVC.App
{
    using MVC;
    using SimpleHttpServer;

    class AppStart
    {
        static void Main(string[] args)
        {
            HttpServer server = new HttpServer(8081, RouteTables.Routes);
            MvcEngine.Run(server);
        }
    }
}
