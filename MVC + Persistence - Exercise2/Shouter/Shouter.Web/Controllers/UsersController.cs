namespace Shouter.Web.Controllers
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
        private readonly SignInManager signInManger;

        public UsersController()
        {
            this.sessions = new DeletableEntityRepository<Session>(ShouterContext.Create());
            this.signInManger = new SignInManager(this.sessions);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }


        [HttpPost]
        public IActionResult Register(RegisterBindingModel model, HttpResponse response)
        {
            RegisterServices service = new RegisterServices();
            service.IsModelValid(model);

           service.RegisterUser(model);

            this.Redirect(response, "/home/index");
            return null;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginBindingModel model,
                                    HttpSession session,
                                    HttpResponse response)
        {
            var loginServices = new LoginServices();

            var currentUser = loginServices
                .GetUser(model, session, response);

            var isAuthenticated = this.signInManger
                .IsAuthenticated(session);

            if (currentUser != null && !isAuthenticated)
            {              
                loginServices.AddSession(session, currentUser.Id);
                this.Redirect(response, "/home/feedSigned");
            }

            if (isAuthenticated)
            {
                this.Redirect(response, "/home/feedSigned");
            }

            return this.View();
        }

        [HttpGet]
        public IActionResult Logout(HttpSession session, HttpResponse response)
        {
            this.signInManger.Logout(response, session.Id);

            this.Redirect(response, "/home/index");
            return null;
        }
    }
}