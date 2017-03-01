namespace PizzaMore.Controllers
{
    using System.Linq;
    using AutoMapper;
    using BindingModels;
    using Security;
    using Data;
    using Models;
    using Services;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;
    using ViewModels;

    public class MenuController : Controller
    {
        private readonly SignInManager signInManager;

        public MenuController()
        {
            this.signInManager = new SignInManager(Data.Context);
        }

        [HttpGet]
        public IActionResult<PizzaSugestionViewModel> Index(HttpSession session)
        {
            if (!this.signInManager.IsAuthenticated(session))
            {
                this.Redirect(new HttpResponse(), "/home/index");
            }

            var menuServices= new MenuServices();
            var model = menuServices.GetModel(session);

            return this.View(model);
        }

        [HttpGet]
        public IActionResult Add(HttpSession session)
        {
            if (!this.signInManager.IsAuthenticated(session))
            {
                return this.View("Users", "SignIn");
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Add(AddPizzaBindingModel model, HttpSession session)
        {
            if (!this.signInManager.IsAuthenticated(session))
            {
                return this.View("User", "SignIn");
            }

            using (var context = Data.Context)
            {
                this.ConfigureMapper(session, context);
                Pizza pizzaEntity = Mapper.Map<Pizza>(model);
                context.Pizzas.Add(pizzaEntity);
                context.SaveChanges();
            }

            return this.View("Menu", "Index");
        }

        public void ConfigureMapper(HttpSession session, PizzaStoreContext context)
        {
            Mapper.Initialize(expression => expression.CreateMap<AddPizzaBindingModel, Pizza>()
            .ForMember(p => p.Owner, confg => confg.MapFrom(
                u =>  context.Sessions.First(s => s.SessionId == session.Id
                ))));
        }
    }
}