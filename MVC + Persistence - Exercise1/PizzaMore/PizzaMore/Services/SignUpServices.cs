namespace PizzaMore.Services
{
    using BindingModels;
    using Data;
    using Models;

    public class SignUpServices : Service
    {
        public SignUpServices(PizzaStoreContext context) 
            : base(context)
        {
        }

        public void AddUser(SignUpBindingModel model)
        {
            User user = new User()
            {
                Email = model.Email,
                Password = model.Password
            };

            this.context.Users.Add(user);
            this.context.SaveChanges();
        }
    }
}
