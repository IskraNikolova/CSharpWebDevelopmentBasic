namespace MvcApp.Web.Controllers
{
    using Data;
    using Data.Common.Repository;
    using Data.Models;
    using Security;
    using Services;
    using SimpleHttpServer.Models;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces.Generic;
    using ViewModels;

    public class CategoriesController : Controller
    {
        private readonly UnitOfWork unit;
        private readonly AuthenticationManager manager;
        private CategoriesServices service;

        public CategoriesController()
        {
            this.unit = new UnitOfWork();
            this.manager = new AuthenticationManager(this.unit.Sessions);
            this.service = new CategoriesServices();
        }

        public IActionResult<AllViewModel> All(HttpSession session, HttpResponse response)
        {
            if (!this.manager.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "forum/register");
                return null;
            }

            User user = this.manager.GetAuthenticationUser(session.Id);
            if (!user.IsAdmin)
            {
                this.Redirect(response, "home/topics");
                return null;
            }

            var model = this.service.GetAllViewModel(user, this.unit.Categories);
            return this.View(model);
        }
    }
}
