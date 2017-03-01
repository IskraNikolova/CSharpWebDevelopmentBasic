namespace PizzaMore.Security
{
    using System;
    using System.Linq;
    using Data;
    using Models;
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
            var isAuth = this.context
                              .Sessions
                              .Any(s => s.SessionId == session.Id && s.IsActive);
            return isAuth;

        }

        public void Logout(HttpSession httpSession)
        {
            using (this.context)
            {
                Session session = this.context
                    .Sessions
                    .FirstOrDefault(s => s.SessionId == httpSession.Id);

                if (session != null)
                {
                    session.IsActive = false;
                    httpSession.Id = new Random().Next().ToString();
                    this.context.SaveChanges();
                }
            }
        }
    }
}