namespace MvcApp.Web.BindingModels
{
    using System;
    using Data.Models;
    using Infrastucture.Mapping;
    using Microsoft.Build.Framework;

    public class RegisterBindingModel : IMapFrom<User>
    {
        [Required]
        public string Username { get; set; }

        public string FullName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }
    }
}