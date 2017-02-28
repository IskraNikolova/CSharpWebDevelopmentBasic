namespace PizzaMore.Services
{
    using System.Linq;
    using BindingModels;
    using Data;
    using Models;
    using SimpleHttpServer.Models;

    public class SignInServices : Service
    {
        public SignInServices(PizzaStoreContext context)
            : base(context)
        {
        }

        public void SignIn(SignInBindingModel model, HttpSession session)
        {
            User user = this.context
                .Users
                .First(u => (u.Email == model.Email && u.Password == model.Password));

            if (user != null)
            {

                Session sessionEntity = new Session()
                {
                    SessionId = session.Id,
                    IsActive = true,
                    User = user
                };

                this.context.Sessions.Add(sessionEntity);
                this.context.SaveChanges();
            }
        }
    }
}