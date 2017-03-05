namespace MvcApp.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class Login : AuditInfo, IDeletableEntity
    {
        [Key]
        public string LoginId { get; set; }

        public bool IsActive { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public override string ToString()
        {
            return $"{this.LoginId}\t{this.User.Id}";
        }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}