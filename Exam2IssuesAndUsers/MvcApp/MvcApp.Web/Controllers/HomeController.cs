namespace MvcApp.Web.Controllers
{
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
            : this(new UnitOfWork())
        {
        }

        public HomeController(UnitOfWork unit)
        {
            this.unit = unit;
            this.authenticationManager = new AuthenticationManager(unit);
        }

        [HttpGet]
        public IActionResult<SignedViewModel> Index(HttpSession session, HttpResponse response)
        {
            var service = new HomeIndexService(this.unit);
            var signedModel = new SignedViewModel();
            if (!this.authenticationManager.IsAuthenticated(session.Id))
            {
                var user = service.GetAutenticationUser(session);
                signedModel.Username = user.Username;
            }
            return this.View(signedModel);
        }
    }
}