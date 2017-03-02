namespace Shouter.Web.Services
{
    using System.Text.RegularExpressions;
    using BindingModels;
    using Data;
    using Data.Common.Repository;
    using Data.Models;

    public class RegisterServices
    {
        private readonly IDeletableEntityRepository<User> users;

        public bool IsModelValid(RegisterBindingModel model)
        {
            //todo validation
            Regex regex = new Regex("^[a-z0-9]+$");
            if (!regex.IsMatch(model.Username))
            {
                return false;
            }

            if (model.Password != model.ConfirmPassword)
            {
                return false;             
            }

            return true;
        }

        public RegisterServices()
        {
            this.users = new DeletableEntityRepository<User>(ShouterContext.Create());
        }

        public void RegisterUser(RegisterBindingModel model)
        {
            User userEntity = new User()
            {
                Email = model.Email,
                Password = model.Password
            };

            using (this.users)
            {
                this.users.Add(userEntity);
                this.users.SaveChanges();
            }
        }
    }
}
