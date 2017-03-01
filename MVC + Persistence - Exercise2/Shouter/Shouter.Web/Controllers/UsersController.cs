namespace Shouter.Web.Controllers
{
    using System.Data.Entity;
    using Data;
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
        private readonly IDeletableEntityRepository<Session> sessions;

        public UsersController()
        {
            this.users = new DeletableEntityRepository<User>(new ShouterContext());
            this.sessions = new DeletableEntityRepository<Session>(new ShouterContext());
        }

        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }


        [HttpPost]
        public IActionResult Register(RegisterViewModel model, HttpResponse response)
        {
            if (model.Password != model.ConfirmPassword)
            {
                this.Redirect(response, "/users/register");
            }

            User userEntity = new User()
            {
                Email = model.Email,
                Password = model.Password
            };

            this.users.Add(userEntity);
            this.users.SaveChanges();

            this.Redirect(response, "/home/index");
            return null;
        }
    }
}