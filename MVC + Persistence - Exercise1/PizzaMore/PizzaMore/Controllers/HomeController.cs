namespace PizzaMore.Controllers
{
    using Data;
    using Security;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;

    public class HomeController : Controller
    {
        private readonly SignInManager signInManager;

        public HomeController()
        {
            this.signInManager = new SignInManager(Data.Context);
        }

        [HttpGet]
        public IActionResult Index(HttpSession session)
        {
            if (this.signInManager.IsAuthenticated(session))
            {
                return this.View("Home", "IndexLogin");
            }

            return this.View();
        }

        [HttpGet]
        public IActionResult IndexLogin()
        {
            return this.View();
        }
    }
}