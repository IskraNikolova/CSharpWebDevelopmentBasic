namespace PizzaMore.Controllers
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
        private readonly SignInManager signInManager;

        public UsersController()
        {
            this.signInManager = new SignInManager(Data.Context);
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult SignUp(SignUpBindingModel model)
        {
            SignUpServices services = new SignUpServices();
            services.AddUser(model);

            return this.View("Home", "IndexLogin");
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult SignIn(SignInBindingModel model, HttpSession session)
        {
            SignInServices services = new SignInServices();
            services.SignIn(model, session);

            return this.View("Home", "IndexLogin");
        }

        [HttpGet]
        public IActionResult Logout(HttpSession session)
        {
            this.signInManager.Logout(session);
            return this.View("Home", "Index");
        }
    }
}