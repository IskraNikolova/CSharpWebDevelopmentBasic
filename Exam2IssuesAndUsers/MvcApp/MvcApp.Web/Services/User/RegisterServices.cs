namespace MvcApp.Web.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using BindingModels;
    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using ViewModels;

    public class RegisterServices : Service
    {
        public RegisterServices(UnitOfWork unit)
            : base(unit)
        {
        }

        public HashSet<RegisterValidationModel> RegisterModelValidator(RegisterBindingModel model)
        {
            var errors = new HashSet<RegisterValidationModel>();
            if (model.Username.Length < 5 || model.Username.Length > 30)
            {
                errors.Add(new RegisterValidationModel() {Message = "Username should be between 5 and 30 symbol!"});
            }

            if (model.FullName.Length < 5)
            {
                errors.Add(new RegisterValidationModel() { Message = "The full name should be at least 5 symbols!" });
            }

            //Regex regex = new Regex("^[\\w]+$");
            //if (!regex.IsMatch(model.Username))
            //{
            //    return false;
            //}

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add(new RegisterValidationModel() { Message = "The password is not a correct format!" });
            }

            if (model.Password.Length < 8)
            {
                errors.Add(new RegisterValidationModel() { Message = "The password is not a correct format!" });
            }

            var hasUpperLetter = false;
            var hasDigit = false;

            foreach (var symbol in model.Password)
            {
                if (char.IsDigit(symbol))
                {
                    hasDigit = true;
                }

                if (char.IsUpper(symbol))
                {
                    hasUpperLetter = true;
                }
            }

            if (!hasDigit || !hasUpperLetter)
            {
                errors.Add(new RegisterValidationModel() { Message = "The password is not a correct format!" });
            }

            return errors;
        }

        public User GetUserOfRegisterBind(RegisterBindingModel model)
        {
           User userEntity = //Mapper.Map<RegisterBindingModel, User>(model);
            new User()
            {
                Username = model.Username,
                Fullname = model.Username,
                Password = model.Password,
            };

            return userEntity;
        }

        public void RegisterUser(User userEntity)
        {
            if (!this.unit.Users.All().Any())
            {
                userEntity.IsAdmin = true;
                userEntity.Role = Role.Admin;
            }
            else
            {
                userEntity.Role = Role.Regular;
            }

            this.unit.Users.Add(userEntity);
            this.unit.Users.SaveChanges();
        }
    }
}