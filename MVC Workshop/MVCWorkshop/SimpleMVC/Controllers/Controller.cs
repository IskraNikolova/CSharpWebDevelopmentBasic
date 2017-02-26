namespace SimpleMVC.Controllers
{
    using System.Runtime.CompilerServices;
    using Interfaces;
    using Interfaces.Generic;
    using SimpleHttpServer.Enums;
    using SimpleHttpServer.Models;
    using ViewEngine;
    using ViewEngine.Generic;

    public class Controller
    {
        protected IActionResult View([CallerMemberName]string callee = "")
        {
            string controllerName = this.GetType()
                .Name
                .Replace(oldValue: MvcContext.Current.ControllersSuffix, newValue: string.Empty);

            string fullQualifedName = string.Format(
                "{0}.{1}.{2}.{3}",
                MvcContext.Current.AssemblyName,
                MvcContext.Current.ViewsFolder,
                controllerName,
                callee);

            return new ActionResult(viewFullQualifedName: fullQualifedName);
        }

        protected IActionResult View(string controller, string action)
        {
            string fullQualifedName = string.Format(
                "{0}.{1}.{2}.{3}",
                MvcContext.Current.AssemblyName,
                MvcContext.Current.ViewsFolder,
                controller,
                action);

            return new ActionResult(viewFullQualifedName: fullQualifedName);
        }

        protected IActionResult<T> View<T>(T model, [CallerMemberName]string callee = "")
        {
            string controllerName = this.GetType()
                .Name
                .Replace(oldValue: MvcContext.Current.ControllersSuffix, newValue: string.Empty);

            string fullQualifedName = string.Format(
               "{0}.{1}.{2}.{3}",
               MvcContext.Current.AssemblyName,
               MvcContext.Current.ViewsFolder,
               controllerName,
               callee);

            return new ActionResult<T>(viewFullQualifiedName: fullQualifedName, model: model);
        }

        protected IActionResult<T> View<T>(T model, string controller, string action)
        {
            string fullQualifedName = string.Format(
                "{0}.{1}.{2}.{3}",
                MvcContext.Current.AssemblyName,
                MvcContext.Current.ViewsFolder,
                controller,
                action);

            return new ActionResult<T>(viewFullQualifiedName: fullQualifedName, model: model);
        }

        public void Redirect(HttpResponse response, string location)
        {
            response.Header.Location = location;
            response.StatusCode = ResponseStatusCode.Found;
        }
    }
}