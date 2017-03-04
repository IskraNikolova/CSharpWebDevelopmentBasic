namespace MvcApp.Web.Controllers
{
    using BindingModels;
    using Data;
    using Security;
    using Services;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;

    public class UsersController : Controller
    {
        private readonly UnitOfWork unit;
        private readonly AuthenticationManager authenticationManger;

        public UsersController() 
            : this(new UnitOfWork(), 
                   new AuthenticationManager())
        {           
        }

        public UsersController(UnitOfWork unit,
            AuthenticationManager manager)
        {
            this.unit = unit;
            this.authenticationManger = manager;
        }

        [HttpGet]
        public IActionResult Register(HttpResponse response, HttpSession session)
        {
            if (this.authenticationManger.IsAuthenticated(session.Id, this.unit.Sessions))
            {
                this.Redirect(response, "home/index");
                return null;
            }

            return this.View();
        }


        [HttpPost]
        public void Register(RegisterBindingModel model, HttpResponse response)
        {
            var service = new RegisterServices(this.unit);
            if (!service.IsRegisterModelValid(model))
            {
                this.Redirect(response, "/users/register");
            }
            else
            {
                var user = service.GetUserOfRegisterBind(model);
                service.RegisterUser(user);
                this.Redirect(response, "/home/index");//todo"users/login"
            }
        }

        [HttpGet]
        public IActionResult Login(HttpResponse response, HttpSession session)
        {
            if (this.authenticationManger.IsAuthenticated(session.Id, this.unit.Sessions))
            {
                this.Redirect(response, "home/signed");
                return null;
            }

            return this.View();
        }

        [HttpPost]
        public void Login(LoginBindingModel model,
                                    HttpSession session,
                                    HttpResponse response)
        {
            var loginServices = new LoginServices(this.unit);

            if (!loginServices.IsLoginViewModelValid(model))
            {
                this.Redirect(response, "/users/login");
            }
            else
            {
                var logginUser = loginServices.GetUserOfLoginBind(model);
                loginServices.LoginUser(logginUser, session);

                this.Redirect(response, "/home/index");//todohome/signed
            }
        }

        [HttpGet]
        public void Logout(HttpSession session, HttpResponse response)
        {
            this.authenticationManger.Logout(response, session.Id, this.unit.Sessions);

            this.Redirect(response, "/home/index");
        }
    }
}