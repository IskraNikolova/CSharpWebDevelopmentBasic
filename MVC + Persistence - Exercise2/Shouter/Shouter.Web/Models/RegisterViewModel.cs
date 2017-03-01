namespace Shouter.Web.Models
{
    using System;
    using Data.Models;
    using Infrastucture.Mapping;
    using Microsoft.Build.Framework;

    public class RegisterViewModel : IMapFrom<User>
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Email { get; set; }

        public DateTime BirthDate { get; set; }
    }
}