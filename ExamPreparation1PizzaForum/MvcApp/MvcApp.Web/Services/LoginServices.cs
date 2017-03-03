namespace MvcApp.Web.Services
{
    using System.Linq;
    using BindingModels;
    using Data;
    using Data.Common.Repository;
    using Data.Models;
    using SimpleHttpServer.Models;

    public class LoginServices
    {
        private readonly IDeletableEntityRepository<User> users;
        private readonly IDeletableEntityRepository<Session> sessions;

        public LoginServices(IDeletableEntityRepository<User> users, 
            IDeletableEntityRepository<Session> sessions)
        {
            this.users = users;
            this.sessions = sessions;
        }

        public bool IsLoginViewModelValid(LoginBindingModel model)
        {
            var cre = model.Credentials;
            var pass = model.Password;
            return this.users.All().Any(u => (u.Email == cre ||
                                             u.Username == cre) &&
                                             u.Password == pass);
        }

        public User GetUserOfLoginBind(LoginBindingModel model)
        {
            User currentUser =
                     this.users.All()
                          .First(u => u.Password == model.Password &&
                                      (u.Username == model.Credentials ||
                                      u.Email == model.Credentials));
            return currentUser;
        }

        public void LoginUser(User user, HttpSession session)
        {
            var sessionEntity = new Session()
            {
                SessionId = session.Id,
                IsActive = true,
                UserId = user.Id
            };

            this.sessions.Add(sessionEntity);
            this.sessions.SaveChanges();
        }
    }
}