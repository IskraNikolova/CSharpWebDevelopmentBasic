namespace SimpleMVC.App.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using BindingModels;
    using Data;
    using Models;
    using Mvc.Attributes.Methods;
    using Mvc.Controllers;
    using Mvc.Interfaces;
    using Mvc.Interfaces.Generic;
    using Mvc.Security;
    using SimpleHttpServer.Models;
    using ViewModel;

    public class UsersController : Controller
    {
        private readonly SignInManager signInManager;

        public UsersController()
        {
            this.signInManager = new SignInManager(new NoteContext());
        }

        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserBindingModel model, HttpSession session, HttpResponse response)
        {
            string userName = model.Username;
            string password = model.Password;
            string sessionId = session.Id;

            using (var context = new NoteContext())
            {
                var user = context
                    .Users
                    .FirstOrDefault(u => u.Username == userName && u.Password == password);

                if (user != null)
                {
                    var login = new Login()
                    {
                        IsActive = true,
                        UserId = user.Id,
                        SessionId = sessionId,
                        User = user
                    };

                    context.Logins.Add(login);
                    context.Save();
                }

                this.Redirect(response,"home/index");
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult<UserViewModel> Register(RegisterUserBindingModel model)
        {
            var user = new User()
            {
                Username = model.Username,
                Password = model.Password
            };

            using (var context = new NoteContext())
            {
                context.Users.Add(user);
                context.Save();
            }

            var viewModel = new UserViewModel()
            {
                Username = model.Username
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult<AllUsernamesViewModel> All(HttpSession session, HttpResponse response)
        {
            if (!this.signInManager.IsAuthenticated(session))
            {
                this.Redirect(response, "login/all");
                return null;
            }

            List<string> usernames = null;

            using (var context = new NoteContext())
            {
                usernames = context.Users.Select(u => u.Username).ToList();
            }

            AllUsernamesViewModel viewModel = new AllUsernamesViewModel()
            {
                Usernames = usernames
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult<UserProfileViewModel> Profile(int id)
        {
            using (var context = new NoteContext())
            {
                var user = context.Users.Find(id);
                var viewModel = new UserProfileViewModel()
                {
                    UserId = user.Id,
                    Username = user.Username,
                    Notes = user.Notes.Select(
                        x => new NoteViewModel()
                        {
                            Title = x.Title,
                            Content = x.Content
                        })
                };

                return this.View(viewModel);
            }
        }

        [HttpGet]
        public IActionResult<GreetViewModel>Greet(HttpSession session)
        {
            var viewModel = new GreetViewModel()
            {
                SessionId = session.Id
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult<UserProfileViewModel> Profile(AddNoteBindingModel model)
        {
            using (var context = new NoteContext())
            {
                var user = context.Users.Find(model.UserId);
                var note = new Note()
                {
                    Title = model.Title,
                    Content = model.Content
                };

                user.Notes.Add(note);
                context.Save();
            }

            return this.Profile(model.UserId);
        }
    }
}