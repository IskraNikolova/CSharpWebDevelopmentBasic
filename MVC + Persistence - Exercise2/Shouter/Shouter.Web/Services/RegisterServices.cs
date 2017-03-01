namespace Shouter.Web.Services
{
    using Data;
    using Data.Common.Repository;
    using Data.Models;
    using Models;

    public class RegisterServices
    {
        private readonly IDeletableEntityRepository<User> users;

        public RegisterServices()
        {
            this.users = new DeletableEntityRepository<User>(ShouterContext.Create());
        }

        public void RegisterUser(RegisterViewModel model)
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
