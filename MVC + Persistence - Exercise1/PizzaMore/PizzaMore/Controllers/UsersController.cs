namespace PizzaMore.Controllers
{
    using AutoMapper;
    using BindingModels;
    using Models;
    using Services;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;

    public class UsersController : Controller
    {
        [HttpGet]
        public IActionResult SignUp()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult SignUp(SignUpBindingModel model)
        {
            SignUpServices services = new SignUpServices(Data.Data.Context);
            services.AddUser(model);

            return this.View("Home", "IndexLogin");
        }

        [HttpGet]
        public IActionResult SignOut()
        {
            return this.View("Home", "Index");
        }


        [HttpGet]
        public IActionResult SignIn()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult SignIn(SignInBindingModel model, HttpSession session)
        {
            SignInServices services = new SignInServices(Data.Data.Context);
            services.SignIn(model, session);

            return this.View("Home", "IndexLogin");
        }
    }
}
