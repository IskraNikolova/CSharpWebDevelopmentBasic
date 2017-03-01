namespace Shouter.Web.Models
{
    using Data.Models;
    using Infrastucture.Mapping;
    using Microsoft.Build.Framework;

    public class DisplayViewModel : IMapFrom<User>
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}