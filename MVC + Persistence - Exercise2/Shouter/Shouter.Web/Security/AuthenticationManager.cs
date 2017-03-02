namespace Shouter.Web.Security
{
    using System.Linq;
    using Data.Common.Repository;
    using Data.Models;
    using SimpleHttpServer.Models;
    using SimpleHttpServer.Utilities;

    public class AuthenticationManager
    {
         private readonly  IDeletableEntityRepository<Session> sessions;

        public AuthenticationManager(IDeletableEntityRepository<Session> context)
        {
            this.sessions = context;
        }

        public bool IsAuthenticated(string sessionId)
        {
            bool isAuthenticated = this.sessions.All()
                .Any(s => s.SessionId == sessionId && s.IsActive);

            return isAuthenticated;
        }

        public User GetAuthenticationUser(string sessionId)
        {
            User user = this.sessions
                .All()
               .FirstOrDefault(s => s.SessionId == sessionId && s.IsActive)
               .User;

            return user;
        }

        public void Logout(HttpResponse response, string sessionId)
        {
            Session sessionEntity = this.sessions
                .All()
                .FirstOrDefault(s => s.SessionId == sessionId);

            sessionEntity.IsActive = false;

            this.sessions.SaveChanges();

            var session = SessionCreator.Create();
            var sessionCookie = new Cookie("sessionId", session.Id + "; HttpOnly; path=/");
            response.Header.AddCookie(sessionCookie);
        }
    }
}