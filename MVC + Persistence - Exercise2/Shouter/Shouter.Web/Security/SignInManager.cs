﻿namespace Shouter.Web.Security
{
    using System.Linq;
    using Data;
    using Data.Common.Repository;
    using Data.Models;
    using SimpleHttpServer.Models;
    using SimpleHttpServer.Utilities;

    public class SignInManager
    {
         private readonly IDeletableEntityRepository<Session> sessions;

        public SignInManager(IDeletableEntityRepository<Session> context)
        {
            this.sessions = context;
        }

        public bool IsAuthenticated(HttpSession session)
        {
            bool isAuthenticated = this.sessions.All()
                .Any(s => s.SessionId == session.Id && s.IsActive);

            return isAuthenticated;
        }

        public void Logout(HttpResponse response, string sessionId)
        {
            Session sessionEntity = this.sessions.All()
                .FirstOrDefault(s => s.SessionId == sessionId);

            sessionEntity.IsActive = false;

            this.sessions.SaveChanges();

            var session = SessionCreator.Create();
            var sessionCookie = new Cookie("sessionId", session.Id + "; HttpOnly; path=/");
            response.Header.AddCookie(sessionCookie);
        }
    }
}