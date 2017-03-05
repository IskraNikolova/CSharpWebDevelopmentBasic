namespace MvcApp.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;
    using Enums;

    public class User : AuditInfo, IDeletableEntity
    {
        public User()
        {
            this.Issues = new HashSet<Issue>();
        }

        [Key]
        public int Id { get; set; }

        public string Username { get; set; }

        public string FullName { get; set; }

        [Required]
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public Role Role { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<Issue> Issues { get; set; }
    }
}