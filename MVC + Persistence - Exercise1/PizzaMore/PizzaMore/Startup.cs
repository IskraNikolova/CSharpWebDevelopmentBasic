namespace PizzaMore
{
    using SimpleHttpServer;
    using SimpleMVC;

    public class Startup
    {
        public static void Main(string[] args)
        {
            HttpServer server = new HttpServer(8081, RouteTable.Routes);
            MvcEngine.Run(server, "PizzaMore");
        }
    }
}
