namespace MvcApp.Web.Controllers
{
    using BindingModels;
    using Security;
    using Services;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;

    public class UsersController : Controller
    {
        private readonly UsersService service;

        public UsersController()
        {
            this.service = new UsersService();
        }

        [HttpGet]
        public IActionResult Register(HttpResponse response, HttpSession session)
        {
            if (new AuthenticationManager().IsAuthenticated(session.Id))
            {
                this.Redirect(response, "home/index");
                return null;
            }

            return this.View();
        }


        [HttpPost]
        public IActionResult Register(RegisterBindingModel model, HttpResponse response)
        {
            if (!this.service.IsRegisterModelValid(model))
            {
                this.Redirect(response, "/users/register");
            }
            else
            {
                var user = this.service.GetUserOfRegisterBind(model);
                this.service.RegisterUser(user);
                this.Redirect(response, "/home/index");//todo"users/login"
            }

            return null;
        }

        [HttpGet]
        public IActionResult Login(HttpResponse response, HttpSession session)
        {
            if (new AuthenticationManager().IsAuthenticated(session.Id))
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
            if (!this.service.IsLoginViewModelValid(model))
            {
                this.Redirect(response, "/users/login");
            }
            else
            {
                var logginUser = this.service.GetUserOfLoginBind(model);
                this.service.LoginUser(logginUser, session);

                this.Redirect(response, "/home/signed");
            }

            return null;
        }

        [HttpGet]
        public void Logout(HttpSession session, HttpResponse response)
        {
            new AuthenticationManager().Logout(response, session.Id);

            this.Redirect(response, "/home/index");
        }
    }
}