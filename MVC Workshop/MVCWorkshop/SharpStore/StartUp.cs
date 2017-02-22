namespace SharpStore
{
    using SimpleHttpServer;
    using SimpleMVC;

    public class StartUp
    {
        public static void Main()
        {
            HttpServer server = new HttpServer(8081, RouteTable.Routes);
            MvcEngine.Run(server, "SharpStore");
        }
    }
}