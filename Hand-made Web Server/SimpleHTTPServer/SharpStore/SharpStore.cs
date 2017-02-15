namespace SharpStore
{
    using System.Threading;
    using SimpleHttpServer.Models;

    public class SharpStore
    {
        public static void Main()
        {
            var routes = RoutesConfig.GetRoutes();
            var server = new HttpServer(8081, routes);
            server.Listen();

            Thread thread = new Thread(server.Listen);
            thread.Start();
        }
    }
}
