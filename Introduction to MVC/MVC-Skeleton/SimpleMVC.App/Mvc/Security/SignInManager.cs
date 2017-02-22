namespace SimpleMVC.App.Mvc.Security
{
    using System.Linq;
    using Interfaces;
    using SimpleHttpServer.Models;

    public class SignInManager
    {
        private readonly IDbIdentityContext dbContext;

        public SignInManager(IDbIdentityContext context)
        {
            this.dbContext = context;
        }

        public bool IsAuthenticated(HttpSession session)
        {
            if (session == null)
            {
                return false;
            }

            var login = this.dbContext.Logins
                .FirstOrDefault(l => l.SessionId == session.Id && l.IsActive);

            return login != null;
        }

        public void Logout(HttpSession session)
        {
            var login = this.dbContext.Logins
                .FirstOrDefault(l => l.SessionId == session.Id && l.IsActive);

            if (login != null)
            {
                login.IsActive = false;
            }
            
            this.dbContext.Save();   
        }
    }
}