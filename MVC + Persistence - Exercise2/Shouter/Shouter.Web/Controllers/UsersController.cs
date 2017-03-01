namespace Shouter.Web.Controllers
{
    using Data.Common.Repository;
    using Data.Models;
    using Models;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;

    public class UsersController : Controller
    {
        private readonly IDeletableEntityRepository<User> users;

        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }


        [HttpPost]
        public IActionResult Register(RegisterViewModel model, HttpResponse response)
        {
            return this.View();
        }
    }
}
