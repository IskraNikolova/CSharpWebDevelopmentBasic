namespace MvcApp.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;
    using Enums;

    public class Issue : AuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Priority Priority { get; set; }

        public Status Status { get; set; }

        [ForeignKey("Author")]
        public int UserId { get; set; }

        public virtual User Author{ get; set; }
       
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
