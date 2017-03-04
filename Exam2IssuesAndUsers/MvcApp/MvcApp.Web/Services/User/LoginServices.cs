namespace MvcApp.Web.Services
{
    using System.Linq;
    using BindingModels;
    using Data;
    using Data.Models;
    using SimpleHttpServer.Models;

    public class LoginServices : Service
    {
        public LoginServices(UnitOfWork unit) 
            : base(unit)
        {
        }

        public bool IsLoginViewModelValid(LoginBindingModel model)
        {
            var cre = model.Username;
            var pass = model.Password;
           
            return this.unit.Users.All()
                .Any(u => u.Username == cre &&  u.Password == pass);
        }

        public User GetUserOfLoginBind(LoginBindingModel model)
        {
            User currentUser =
                     this.unit.Users.All()
                          .First(u => u.Password == model.Password &&
                                      u.Username == model.Username);
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

            this.unit.Sessions.Add(sessionEntity);
            this.unit.Sessions.SaveChanges();
        }
    }
}