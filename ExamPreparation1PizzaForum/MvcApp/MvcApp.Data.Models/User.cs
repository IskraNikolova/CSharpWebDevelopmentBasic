namespace MvcApp.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;

    public class User : AuditInfo, IDeletableEntity
    {
        public User()
        {
            this.Topics = new HashSet<Topic>();
        }

        public int Id { get; set; }

        [StringLength(450)]
        [MinLength(3)]
        [Index(IsUnique = true)]
        public string Username { get; set; }

        [Index("Email", IsUnique = true)]
        [StringLength(450)]
        public string Email { get; set; }

        [RegularExpression(@"^\d{4}$")]
        [Column(TypeName = "char")]
        [StringLength(4)]
        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}