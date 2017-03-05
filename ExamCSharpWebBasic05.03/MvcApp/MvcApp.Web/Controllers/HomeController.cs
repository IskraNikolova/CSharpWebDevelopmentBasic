namespace MvcApp.Web.Controllers
{
    using Security;
    using Services;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;
    using ViewModels;

    public class HomeController : Controller
    {
        private HomeService service;

        public HomeController()
        {
            this.service = new HomeService();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return this.View();
        }


        [HttpGet]
        public IActionResult<SignedViewModel> Signed(HttpSession session, HttpResponse response)
        {
            if (!new AuthenticationManager().IsAuthenticated(session.Id))
            {
                this.Redirect(response, "/home/index");
            }

                //var user = this.unit.Sessions
                //                   .All()
                //                   .FirstOrDefault(s => s.LoginId == session.Id)
                //                   .User;
                //if (user != null)
                //{
                //    var viewModel = new SignedViewModel()
                //    {
                //        Username = user.Username
                //    };

                //    return this.View(viewModel);
                //}

                return null;
        }
    }
}