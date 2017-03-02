namespace Shouter.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class User : AuditInfo, IDeletableEntity
    {
        public User()
        {
            this.Users = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }

        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        [Required]
        public string Email { get; set; }

        public DateTime? BirthDate { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}