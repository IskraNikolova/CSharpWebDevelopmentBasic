namespace SimpleMVC
{
    using System;
    using System.Reflection;
    using SimpleHttpServer;

    public static class MvcEngine
    {
        public static void Run(HttpServer server, string applicationAssemblyName)
        {
            RegisterAssemblyName(applicationAssemblyName: applicationAssemblyName);
            LoadApplicationAssembly(applicationAssemblyName: applicationAssemblyName);
            RegisterControllers();
            RegisterViews();
            RegisterModels();

            try
            {
                server.Listen();
            }
            catch (Exception e)
            {
                Console.WriteLine(value: e.Message);
            }
        }

        private static void LoadApplicationAssembly(string applicationAssemblyName)
        {
            MvcContext.Current.ApplicationAssembly = Assembly.Load(assemblyString: applicationAssemblyName);
        }

        private static void RegisterAssemblyName(string applicationAssemblyName)
        {
            MvcContext.Current.AssemblyName = applicationAssemblyName;
        }

        private static void RegisterControllers()
        {
            MvcContext.Current.ControllersFolder = "Controllers";
            MvcContext.Current.ControllersSuffix = "Controller";
        }

        private static void RegisterViews()
        {
            MvcContext.Current.ViewsFolder = "Views";
        }

        private static void RegisterModels()
        {
            MvcContext.Current.ModelsFolder = "Models";
        }
    }
}