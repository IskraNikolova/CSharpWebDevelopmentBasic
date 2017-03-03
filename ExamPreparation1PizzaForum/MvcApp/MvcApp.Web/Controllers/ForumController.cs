namespace MvcApp.Web.Controllers
{
    using BindingModels;
    using Data;
    using Data.Common.Repository;
    using Data.Models;
    using Security;
    using Services;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;

    public class ForumController : Controller
    {
        private UnitOfWork unit;
        private readonly AuthenticationManager authenticationManger;

        public ForumController()
        {
            this.unit = new UnitOfWork();
            this.authenticationManger = new AuthenticationManager(this.unit.Sessions);
        }

        [HttpGet]
        public IActionResult Register(HttpResponse response, HttpSession session)
        {
            if (this.authenticationManger.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "home/index");
                return null;
            }

            return this.View();
        }


        [HttpPost]
        public IActionResult Register(RegisterBindingModel model, HttpResponse response)
        {
            var service = new RegisterServices();
            if (!service.IsRegisterModelValid(model))
            {
                this.Redirect(response, "/forum/register");
            }
            else
            {
                var user = service.GetUserOfRegisterBind(model);
                service.RegisterUser(user);
                this.Redirect(response, "/forum/login");
            }

            return null;
        }

        [HttpGet]
        public IActionResult Login(HttpResponse response, HttpSession session)
        {
            if (this.authenticationManger.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "home/index");
                return null;
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginBindingModel model,
                                    HttpSession session,
                                    HttpResponse response)
        {
            var loginServices = new LoginServices(this.unit.Users, this.unit.Sessions);

            if (!loginServices.IsLoginViewModelValid(model))
            {
                this.Redirect(response, "/forum/login");
            }
            else
            {
                var logginUser = loginServices.GetUserOfLoginBind(model);
                loginServices.LoginUser(logginUser, session);

                this.Redirect(response, "/home/index");
            }

            return null;
        }

        [HttpGet]
        public void Logout(HttpSession session, HttpResponse response)
        {
            this.authenticationManger.Logout(response, session.Id);

            this.Redirect(response, "/home/index");
        }
    }
}