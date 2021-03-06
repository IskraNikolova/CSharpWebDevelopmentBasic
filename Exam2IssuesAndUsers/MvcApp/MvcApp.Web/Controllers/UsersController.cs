﻿namespace MvcApp.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using BindingModels;
    using Data;
    using Security;
    using Services;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;
    using ViewModels;

    public class UsersController : Controller
    {
        private readonly UnitOfWork unit;
        private readonly AuthenticationManager authenticationManger;

        public UsersController() 
            : this(new UnitOfWork())
        {           
        }

        public UsersController(UnitOfWork unit)
        {
            this.unit = unit;
            this.authenticationManger = new AuthenticationManager(unit);
        }

        [HttpGet]
        public IActionResult<HashSet<RegisterValidationModel>> Register(HttpResponse response, HttpSession session)
        {
            return this.View(new HashSet<RegisterValidationModel>());
        }


        [HttpPost]
        public IActionResult<HashSet<RegisterValidationModel>> Register(RegisterBindingModel model, HttpResponse response)
        {
            var service = new RegisterServices(this.unit);
            var errors = service.RegisterModelValidator(model);
            if (errors.Any())
            {
                return this.View(errors);
            }

            service.RegisterUser(service.GetUserOfRegisterBind(model));
            this.Redirect(response, "users/login");
            return this.View(new HashSet<RegisterValidationModel>());
        }

        [HttpGet]
        public IActionResult Login(HttpResponse response, HttpSession session)
        {
            if (this.authenticationManger.IsAuthenticated(session.Id))
            {
                this.Redirect(response, "home/index");
                return null;
            }

            return this.View();
        }

        [HttpPost]
        public void Login(LoginBindingModel model,
                                    HttpSession session,
                                    HttpResponse response)
        {
            var loginServices = new LoginServices(this.unit);

            if (!loginServices.IsLoginViewModelValid(model))
            {
                this.Redirect(response, "/users/login");
            }
            else
            {
                var logginUser = loginServices.GetUserOfLoginBind(model);
                loginServices.LoginUser(logginUser, session);

                this.Redirect(response, "/home/index");//todohome/signed
            }
        }

        [HttpGet]
        public void Logout(HttpSession session, HttpResponse response)
        {
            this.authenticationManger.Logout(response, session.Id);

            this.Redirect(response, "/home/index");
        }
    }
}