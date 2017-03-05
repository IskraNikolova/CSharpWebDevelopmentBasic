namespace MvcApp.Web.Services
{
    using System.Linq;
    using System.Text.RegularExpressions;
    using BindingModels;
    using Data.Models;
    using SimpleHttpServer.Models;

    public class UsersService : Service
    {
        public bool IsRegisterModelValid(RegisterBindingModel model)
        {
            //todo validation
            Regex regex = new Regex("^[\\w]+$");
            if (!regex.IsMatch(model.Username))
            {
                return false;
            }

            if (model.Password != model.ConfirmPassword)
            {
                return false;
            }

            return true;
        }

        public User GetUserOfRegisterBind(RegisterBindingModel model)
        {
            User userEntity = new User()
            {
                Username = model.Username,
                Password = model.Password,
            };

            return userEntity;
        }

        public void RegisterUser(User userEntity)
        {
            if (!this.Context.Users.All().Any())
            {
                userEntity.IsAdmin = true;
            }

            this.Context.Users.Add(userEntity);
            this.Context.Users.SaveChanges();
        }
    
    public bool IsLoginViewModelValid(LoginBindingModel model)
        {
            var cre = model.Credentials;
            var pass = model.Password;

            return this.Context.Users.All()
                .Any(u => u.Username == cre && u.Password == pass);
        }

        public User GetUserOfLoginBind(LoginBindingModel model)
        {
            User currentUser =
                     this.Context.Users.All()
                          .First(u => u.Password == model.Password &&
                                      u.Username == model.Credentials);
            return currentUser;
        }

        public void LoginUser(User user, HttpSession session)
        {
            var sessionEntity = new Login()
            {
                LoginId = session.Id,
                IsActive = true,
                UserId = user.Id
            };

            this.Context.Sessions.Add(sessionEntity);
            this.Context.Sessions.SaveChanges();
        }
    }
}
