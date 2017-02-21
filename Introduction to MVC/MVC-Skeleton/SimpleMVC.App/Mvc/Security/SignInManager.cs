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
            var returnResult = this.dbContext
                .Logins
                .FirstOrDefault(l => l.SessionId == session.Id && l.IsActive);

            return returnResult != null;
        }
    }
}
