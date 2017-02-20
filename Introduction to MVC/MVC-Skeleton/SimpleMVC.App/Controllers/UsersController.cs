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
        [HttpGetAttributes]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPostAttributes]
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
    }
}
