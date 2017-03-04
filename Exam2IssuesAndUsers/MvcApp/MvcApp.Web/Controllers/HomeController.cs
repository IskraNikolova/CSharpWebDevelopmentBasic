namespace MvcApp.Web.Controllers
{
    using System.IO;
    using Data;
    using Security;
    using Services.Home;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;
    using ViewModels;

    public class HomeController : Controller
    {
        private readonly UnitOfWork unit;
        private readonly AuthenticationManager authenticationManager;

        public HomeController()
            : this(new UnitOfWork(), new AuthenticationManager())
        {
        }

        public HomeController(UnitOfWork unit, AuthenticationManager manager)
        {
            this.unit = unit;
            this.authenticationManager = manager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult<SignedViewModel> SignedHome(HttpSession session, HttpResponse response)
        {

            if (!this.authenticationManager.IsAuthenticated(session.Id, this.unit.Sessions))
            {
                this.Redirect(response, "/home/index");
            }

            var service = new HomeIndexService(this.unit);
            var user = service.GetAutenticationUser(session);

            if (user != null)
            {
                var viewModel = new SignedViewModel()
                {
                    Username = user.Username
                };

                return this.View(viewModel);
            }

            return null;
        }
    }
}