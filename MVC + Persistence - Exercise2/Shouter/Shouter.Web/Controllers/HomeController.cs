namespace Shouter.Web.Controllers
{
    using System.Linq;
    using System.Security.Cryptography;
    using Data;
    using Data.Common.Repository;
    using Data.Models;
    using Models;
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
        private readonly SignInManager signInManager;

        public HomeController()
        {
            this.sessions = new DeletableEntityRepository<Session>(ShouterContext.Create());
            this.signInManager = new SignInManager(this.sessions);
        }

        [HttpGet]
        public IActionResult Feed()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return this.View();
        }


        [HttpGet]
        public IActionResult<SignedViewModel> FeedSigned(HttpSession session)
        {
            if (!this.signInManager.IsAuthenticated(session))
            {
                this.Redirect(new HttpResponse(), "/home/index");
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