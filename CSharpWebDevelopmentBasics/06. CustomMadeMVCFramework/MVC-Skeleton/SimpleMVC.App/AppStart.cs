namespace SimpleMVC.App
{
    using System.Linq;
    using Data;
    using MVC;
    using SimpleHttpServer;

    class AppStart
    {
        static void Main(string[] args)
        {
            var context = new NotesContext();

            HttpServer server = new HttpServer(8081, RouteTables.Routes);
            MvcEngine.Run(server);
        }
    }
}
