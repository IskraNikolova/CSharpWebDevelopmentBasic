namespace MvcApp.Web.Controllers
{
    using BindingModels;
    using Data;
    using Data.Common.Repository;
    using Data.Models;
    using Security;
    using Services;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;
    using ViewModels;

    public class CategoriesController : Controller
    {
        private readonly UnitOfWork unit;
        private readonly AuthenticationManager manager;
        private readonly CategoriesServices service;

        public CategoriesController()
        {
            this.unit = new UnitOfWork();
            this.manager = new AuthenticationManager(this.unit.Sessions);
            this.service = new CategoriesServices();
        }

        [HttpGet]
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

        [HttpGet]
        public IActionResult New(HttpResponse response, HttpSession session)
        {
            this.manager.GetAuthenticationUser(session.Id);
            return this.View();
        }

        [HttpPost]
        public void New(HttpResponse response, HttpSession session, NewCategoryBindingModel bind)
        {
            this.manager.GetAuthenticationUser(session.Id);

            if (!this.service.IsNewCategoryValid(bind))
            {
                this.Redirect(response, "/categories/new");
            }

            this.service.AddNewCategory(bind, this.unit.Categories);
            this.Redirect(response, "/categories/all");
        }
    }
}