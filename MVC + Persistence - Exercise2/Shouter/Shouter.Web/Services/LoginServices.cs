namespace Shouter.Web.Services
{
    using System.Linq;
    using Data;
    using Data.Common.Repository;
    using Data.Models;
    using Models;
    using SimpleHttpServer.Models;

    public class LoginServices
    {
        private readonly IDeletableEntityRepository<User> users;
        private readonly IDeletableEntityRepository<Session> sessions;

        public LoginServices()
        {
            this.users = new DeletableEntityRepository<User>(ShouterContext.Create());
            this.sessions = new DeletableEntityRepository<Session>(ShouterContext.Create());
        }


        public User GetUser(LoginViewModel model,
                                    HttpSession session,
                                    HttpResponse response)
        {
            User currentUser =
                     this.users.All()
                          .FirstOrDefault(u => u.Password == model.Password &&
                                          u.Email == model.Email);
            return currentUser;
        }

        public void AddSession(HttpSession session, int id)
        {
            Session sessionEntity = new Session()
            {
                SessionId = session.Id,
                IsActive = true,
                UserId = id
            };

            using (this.sessions)
            {
                this.sessions.Add(sessionEntity);
                this.sessions.SaveChanges();
            }
        }
    }
}
