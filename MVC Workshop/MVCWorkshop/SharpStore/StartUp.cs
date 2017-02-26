namespace SharpStore
{
    using SimpleHttpServer;
    using SimpleMVC;

    public class StartUp
    {
        public static void Main()
        {
            HttpServer server = new HttpServer(port: 8081, routes: RouteTable.Routes);
            MvcEngine.Run(server: server, applicationAssemblyName: "SharpStore");
        }
    }
}