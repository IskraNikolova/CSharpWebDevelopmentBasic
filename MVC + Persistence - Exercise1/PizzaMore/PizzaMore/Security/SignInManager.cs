namespace PizzaMore.Security
{
    using System.Linq;
    using Data;
    using SimpleHttpServer.Models;

    public class SignInManager
    {
        private readonly PizzaStoreContext context;

        public SignInManager(PizzaStoreContext context)
        {
            this.context = context;
        }

        public bool IsAuthenticated(HttpSession session)
        {
            return this.context.Sessions.Any(s => s.SessionId == session.Id && s.IsActive);
        }
    }
}