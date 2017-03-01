namespace PizzaMore.Services
{
    using System.Linq;
    using BindingModels;
    using Data;
    using Models;
    using SimpleHttpServer.Models;

    public class SignInServices
    {
        public void SignIn(SignInBindingModel model, HttpSession session)
        {
            using (var context = Data.Context)
            {
                User user = context
                        .Users
                        .First(u => (u.Email == model.Email && u.Password == model.Password));

                if (user != null)
                {
                    Session sessionEntity = new Session()
                    {
                        SessionId = session.Id,
                        IsActive = true,
                        UserId = user.Id
                    };

                    context.Sessions.Add(sessionEntity);
                    context.SaveChanges();
                }
            }
        }
    }
}