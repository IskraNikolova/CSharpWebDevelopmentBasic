namespace SimpleMVC.App.Mvc.Controllers
{
    using System.Runtime.CompilerServices;
    using Interfaces;
    using Interfaces.Generic;
    using Mvc;
    using SimpleHttpServer.Enums;
    using SimpleHttpServer.Models;
    using ViewEngine;
    using ViewEngine.Generic;

    public abstract class Controller
    {
        protected IActionResult View([CallerMemberName] string calle = "")
        {
            string controllerName = this.GetType()
                .Name
                .Replace(Mvc.MvcContext.Current.ControllersSuffix, string.Empty);

            string fullQualifedName = string.Format(
                    $"{MvcContext.Current.AssemblyName}.{MvcContext.Current.ViewsFolder}.{controllerName}.{calle}"
                );

            return new ActionResult(fullQualifedName);
        }

        protected IActionResult View(string controller, string action)
        {
            string fullQualifedName = string.Format(
                    $"{MvcContext.Current.AssemblyName}.{MvcContext.Current.ViewsFolder}.{controller}.{action}"
                );

            return new ActionResult(fullQualifedName);
        }

        protected IActionResult<T> View<T>(T model, [CallerMemberName] string calle = "")
        {
            string controllerName = this.GetType()
                .Name
                .Replace(MvcContext.Current.ControllersSuffix, string.Empty);

            string fullQualifedName = string.Format(
                    $"{MvcContext.Current.AssemblyName}.{MvcContext.Current.ViewsFolder}.{controllerName}.{calle}"
                );

            return new ActionResult<T>(fullQualifedName, model);
        }

        protected IActionResult<T> View<T>(T model, string controller, string action)
        {
            string fullQualifedName = string.Format(
                    $"{MvcContext.Current.AssemblyName}.{MvcContext.Current.ViewsFolder}.{controller}.{action}"
                );

            return new ActionResult<T>(fullQualifedName, model);
        }
        protected void Redirect(HttpResponse response, string location)
        {
            response.Header.Location = location;
            response.StatusCode = ResponseStatusCode.Found;
        }

        protected IActionResult Redirect(string location, [CallerMemberName] string callee = "")
        {
            string controllerName = this.GetType()
                .Name
                .Replace(MvcContext.Current.ControllersSuffix, string.Empty);

            string fullQualifiedName = string.Format(
                "{0}.{1}.{2}.{3}",
                MvcContext.Current.AssemblyName,
                MvcContext.Current.ViewsFolder,
                controllerName,
                callee);

            return new ActionResult(fullQualifiedName, location);
        }

        protected IActionResult<T> Redirect<T>(T model, string location, [CallerMemberName] string callee = "")
        {
            string controllerName = this.GetType()
                .Name
                .Replace(MvcContext.Current.ControllersSuffix, string.Empty);

            string fullQualifiedName = string.Format(
                "{0}.{1}.{2}.{3}",
                MvcContext.Current.AssemblyName,
                MvcContext.Current.ViewsFolder,
                controllerName,
                callee);

            return new ActionResult<T>(fullQualifiedName, model, location);
        }
    }
}
