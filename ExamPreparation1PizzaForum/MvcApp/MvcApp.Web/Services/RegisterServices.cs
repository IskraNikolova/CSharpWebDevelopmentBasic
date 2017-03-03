namespace MvcApp.Web.Services
{
    using System.Linq;
    using System.Text.RegularExpressions;
    using BindingModels;
    using Data;
    using Data.Common.Repository;
    using Data.Models;

    public class RegisterServices
    {
        private readonly IDeletableEntityRepository<User> users;

        public RegisterServices()
        {
            this.users = new DeletableEntityRepository<User>(MvcAppContext.Create());
        }

        public bool IsRegisterModelValid(RegisterBindingModel model)
        {
            //todo validation
            Regex regex = new Regex("^[\\w]+$");
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

        public User GetUserOfRegisterBind(RegisterBindingModel model)
        {
            User userEntity = new User()
            {
                Username = model.Username,
                Email = model.Email,
                Password = model.Password,
            };

            return userEntity;
        }

        public void RegisterUser(User userEntity)
        {
            if (!this.users.All().Any())
            {
                userEntity.IsAdmin = true;
            }

            this.users.Add(userEntity);
            this.users.SaveChanges();
        }
    }
}