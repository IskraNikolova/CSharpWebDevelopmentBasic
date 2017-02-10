namespace FirstRun
{
    using System.Collections.Generic;
    using System.Threading;
    using SimpleHttpServer.Enums;
    using SimpleHttpServer.Models;

    public class Run
    {
        public static void Main()
        {
            var routes = new List<Route>(){
                new Route() {
                    Name = "Hello Handler",
                    UrlRegex = @"^/hello$",
                    Method = RequestMethod.GET,
                    Callable = (HttpRequest request) =>{
                                   return new HttpResponse()
                                   {
                                       ContentAsUTF8 = "<h3>Hello :)</h3>",
                                       StatusCode = ResponseStatusCode.Ok
                                   };
                               }
                      }
                };

            HttpServer server = new HttpServer(8081,routes);
            server.Listen();

            Thread thread = new Thread(new ThreadStart(server.Listen));
            thread.Start();
        }
    }
}