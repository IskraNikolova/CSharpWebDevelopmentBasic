namespace MvcApp.Web.Security
{
    using System.Linq;
    using Data.Common.Repository;
    using Data.Models;
    using SimpleHttpServer.Models;
    using SimpleHttpServer.Utilities;

    public class AuthenticationManager
    {
        public bool IsAuthenticated(string sessionId, IDeletableEntityRepository<Login> sessions)
        {
            bool isAuthenticated = sessions.All()
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

        public void Logout(HttpResponse response, string sessionId, IDeletableEntityRepository<Login> sessions )
        {
            Login loginEntity = sessions
                .All()
                .FirstOrDefault(s => s.LoginId == sessionId);

            loginEntity.IsActive = false;

            sessions.SaveChanges();

            var session = SessionCreator.Create();
            var sessionCookie = new Cookie("sessionId", session.Id + "; HttpOnly; path=/");
            response.Header.AddCookie(sessionCookie);
        }
    }
}