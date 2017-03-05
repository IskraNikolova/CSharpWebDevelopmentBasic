namespace MvcApp.Web.Security
{
    using System.Linq;
    using Data.Common.Repository;
    using Data.Contracts;
    using Data.Models;
    using DependancyContainer;
    using Ninject;
    using SimpleHttpServer.Models;
    using SimpleHttpServer.Utilities;

    public class AuthenticationManager
    {
        public IUnitOfWork Context { get; }

        public AuthenticationManager()
        {
            this.Context = DependencyKernel.Kernel.Get<IUnitOfWork>();
        }

        public  bool IsAuthenticated(string sessionId)
        {
            return this.Context
                       .Sessions.All().ToList()
                       .Any(login => login.LoginId == sessionId && login.IsActive);
        }

        public User GetAuthenticationUser(string sessionId)
        {
            User user = this.Context
                       .Sessions.All()
               .FirstOrDefault(s => s.LoginId == sessionId && s.IsActive)?
               .User;

            return user;
        }

        public void Logout(HttpResponse response, string sessionId)
        {
            Login loginEntity = this.Context
                       .Sessions.All()
                .FirstOrDefault(s => s.LoginId == sessionId);

            loginEntity.IsActive = false;

            this.Context.Save();

            var session = SessionCreator.Create();
            var sessionCookie = new Cookie("sessionId", session.Id + "; HttpOnly; path=/");
            response.Header.AddCookie(sessionCookie);
        }
    }
}