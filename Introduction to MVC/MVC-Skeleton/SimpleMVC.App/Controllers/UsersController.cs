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
    using ViewModel;

    public class UsersController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
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
                context.SaveChanges();
            }

            var viewModel = new UserViewModel()
            {
                Username = model.Username
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult<IEnumerable<AllUsernamesViewModel>> All()
        {
            IList<User> users = null;

            using (var context = new NoteContext())
            {
                users = context.Users.ToList();
            }

            var viewModels = new List<AllUsernamesViewModel>();

            foreach (var user in users)
            {
                viewModels.Add(new AllUsernamesViewModel()
                {
                    Username = user.Username,
                    Id = user.Id
                });
            }

            return this.View(viewModels.AsEnumerable());
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
                context.SaveChanges();
            }

            return this.Profile(model.UserId);
        }
    }
}
