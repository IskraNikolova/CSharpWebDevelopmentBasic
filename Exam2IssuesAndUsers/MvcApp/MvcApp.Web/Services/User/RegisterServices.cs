namespace MvcApp.Web.Services
{
    using System.Linq;
    using BindingModels;
    using Data;
    using Data.Models;

    public class RegisterServices : Service
    {
        public RegisterServices(UnitOfWork unit) 
            : base(unit)
        {
        }

        public bool IsRegisterModelValid(RegisterBindingModel model)
        {
            //if (model.Username.Length < 5 || model.Username.Length > 30)
            //{
            //    return false;
            //}

            //if (model.FullName.Length < 5)
            //{
            //    return false;
            //}

            //Regex regex = new Regex("^[\\w]+$");
            //if (!regex.IsMatch(model.Username))
            //{
            //    return false;
            //}

            //if (model.Password != model.ConfirmPassword)
            //{
            //    return false;
            //}

            //if (model.Password.Length < 8)
            //{
            //    return false;
            //}

            //var hasUpperLetter = false;
            //var hasDigit = false;

            //foreach (var symbol in model.Password)
            //{
            //    if (char.IsDigit(symbol))
            //    {
            //        hasDigit = true;
            //    }

            //    if (char.IsUpper(symbol))
            //    {
            //        hasUpperLetter = true;
            //    }
            //}

            //if (!hasDigit || !hasUpperLetter)
            //{
            //    return false;
            //}

            return true;
        }

        public User GetUserOfRegisterBind(RegisterBindingModel model)
        {
            User userEntity = //Mapper.Map<RegisterBindingModel, User>(model);
            new User()
            {
                Username = model.Username,
                Password = model.Password,
            };

            return userEntity;
        }

        public void RegisterUser(User userEntity)
        {
            if (!this.unit.Users.All().Any())
            {
                userEntity.IsAdmin = true;
            }

            this.unit.Users.Add(userEntity);
            this.unit.Users.SaveChanges();
        }
    }
}