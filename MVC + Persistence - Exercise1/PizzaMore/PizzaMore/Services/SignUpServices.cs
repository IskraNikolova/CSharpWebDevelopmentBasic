namespace PizzaMore.Services
{
    using BindingModels;
    using Data;
    using Models;
    using SimpleHttpServer.Models;

    public class SignUpServices
    {
        public void AddUser(SignUpBindingModel model)
        {
            using (var context = Data.Context)
            {
                User user = new User()
                {
                    Email = model.Email,
                    Password = model.Password
                };

                context.Users.Add(user);
                context.SaveChanges();
            }
        }
    }
}