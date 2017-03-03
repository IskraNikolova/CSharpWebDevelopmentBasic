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

    public class UsersController : Controller
    {
        private readonly IDeletableEntityRepository<Session> sessions;
        private readonly AuthenticationManager authenticationManger;

        public UsersController()
        {
            this.sessions = new DeletableEntityRepository<Session>(MvcAppContext.Create());
            this.authenticationManger = new AuthenticationManager(this.sessions);
        }

        [HttpGet]
        public IActionResult Register(HttpResponse response, HttpSession session)
        {
            if (this.authenticationManger.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "home/signed");
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
                this.Redirect(response, "/users/register");
            }
            else
            {
                var user = service.GetUserOfRegisterBind(model);
                service.RegisterUser(user);
                this.Redirect(response, "/users/login");
            }

            return null;
        }

        [HttpGet]
        public IActionResult Login(HttpResponse response, HttpSession session)
        {
            if (this.authenticationManger.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "home/signed");
                return null;
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginBindingModel model,
                                    HttpSession session,
                                    HttpResponse response)
        {
            var loginServices = new LoginServices();

            if (!loginServices.IsLoginViewModelValid(model))
            {
                this.Redirect(response, "/users/login");
            }
            else
            {
                var logginUser = loginServices.GetUserOfLoginBind(model);
                loginServices.LoginUser(logginUser, session);

                this.Redirect(response, "/home/signed");
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