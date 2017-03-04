namespace MvcApp.Web.Controllers
{
    using System.Linq;
    using Data;
    using Data.Common.Repository;
    using Data.Models;
    using Security;
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
        public IActionResult<SignedViewModel> Signed(HttpSession session, HttpResponse response)
        {
            if (!this.authenticationManager.IsAuthenticated(session.Id, this.unit.Sessions))
            {
                this.Redirect(response, "/home/index");
            }

            using (this.unit.Sessions)
            {
                var user = this.unit.Sessions
                                   .All()
                                   .FirstOrDefault(s => s.LoginId == session.Id)
                                   .User;
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
}