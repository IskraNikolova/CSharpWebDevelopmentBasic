namespace MvcApp.Web.Security
{
    using System.Linq;
    using Data;
    using Data.Common.Repository;
    using Data.Models;
    using SimpleHttpServer.Models;
    using SimpleHttpServer.Utilities;
    using Login = Data.Models.Login;

    public class AuthenticationManager
    {
        private UnitOfWork unit;

        public AuthenticationManager(UnitOfWork unit)
        {
            this.unit = unit;
        }

        public bool IsAuthenticated(string sessionId)
        {
            bool isAuthenticated = this.unit.Sessions.All()
                .Any(s => s.LoginId == sessionId && s.IsActive);

            return isAuthenticated;
        }

        public User GetAuthenticationUser(string sessionId, IDeletableEntityRepository<Login> sessions)
        {
            User user = sessions
                .All()
               .FirstOrDefault(s => s.LoginId == sessionId && s.IsActive)
               .User;

            return user;
        }

        public void Logout(HttpResponse response, string sessionId)
        {
            Login loginEntity = this.unit.Sessions
                .All()
                .FirstOrDefault(s => s.LoginId == sessionId);

            loginEntity.IsActive = false;

            this.unit.Sessions.SaveChanges();

            var session = SessionCreator.Create();
            var sessionCookie = new Cookie("sessionId", session.Id + "; HttpOnly; path=/");
            response.Header.AddCookie(sessionCookie);
        }
    }
}