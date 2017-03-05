namespace MvcApp.Web.BindingModels
{
    using Data.Models;
    using Infrastucture.Mapping;
    using Microsoft.Build.Framework;

    public class LoginBindingModel : IMapFrom<User>
    {
        [Required]
        public string Credentials { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
