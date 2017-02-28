namespace IssueTracker.Web
{
    using SimpleHttpServer;
    using SimpleMVC;

    class AppStart
    {
        static void Main()
        {
            HttpServer server = new HttpServer(8081,RouteTable.Routes);
            MvcEngine.Run(server, "IssueTracker.Web");
        }
    }
}
