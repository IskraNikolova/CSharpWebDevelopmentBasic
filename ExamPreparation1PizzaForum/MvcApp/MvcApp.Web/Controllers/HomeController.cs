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
        private readonly IDeletableEntityRepository<Session> sessions;
        private readonly AuthenticationManager authenticationManager;

        public HomeController()
        {
            this.sessions = new DeletableEntityRepository<Session>(MvcAppContext.Create());
            this.authenticationManager = new AuthenticationManager(this.sessions);
        }


        [HttpGet]
        public IActionResult Index()
        {
            return this.View();
        }


        [HttpGet]
        public IActionResult<SignedViewModel> Signed(HttpSession session, HttpResponse response)
        {
            if (!this.authenticationManager.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/home/index");
            }

            using (this.sessions)
            {
                var user = this.sessions
                                   .All()
                                   .FirstOrDefault(s => s.SessionId == session.Id)
                                   .User;
                if (user != null)
                {
                    var viewModel = new SignedViewModel()
                    {
                        Username = user.Email
                    };

                    return this.View(viewModel);
                }

                return null;
            }
        }
    }
}