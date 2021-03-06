﻿namespace Shouter.Web
{
    using System.Reflection;
    using App_Star;
    using Infrastucture.Mapping;
    using SimpleHttpServer;
    using SimpleMVC;

    public class Startup
    {
        public static void Main()
        {
            var autoMapperConfig = new AutoMapperConfig(Assembly.GetExecutingAssembly());
            autoMapperConfig.Execute();
            NinjectWebKernel.Start();
            HttpServer server = new HttpServer(8081, RouteConfig.Routes);
            MvcEngine.Run(server, "Shouter.Web");
        }
    }
}