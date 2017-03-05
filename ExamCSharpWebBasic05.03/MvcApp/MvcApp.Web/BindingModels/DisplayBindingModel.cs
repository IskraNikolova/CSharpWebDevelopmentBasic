namespace MvcApp.Web.BindingModels
{
    using Data.Models;
    using Infrastucture.Mapping;
    using Microsoft.Build.Framework;

    public class DisplayBindingModel : IMapFrom<User>
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}