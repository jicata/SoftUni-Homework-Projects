namespace SimpleMVC.App.MVC.Interfaces
{
    using SimpleHttpServer.Models;

    public interface IHandleable
    {
        HttpResponse Handle(HttpRequest request);

    }
}
