namespace SimpleMVC.App.Mvc.Interfaces
{
    using Routes;
    using SimpleHttpServer.Models;

    public interface IHandleable
    {
        HttpResponse Handle(HttpRequest request);
    }
}