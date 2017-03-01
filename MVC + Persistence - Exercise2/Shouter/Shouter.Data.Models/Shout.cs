namespace Shouter.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;
    public class Shout : AuditInfo, IDeletableEntity
    {
        [Key]
        public int Id  { get; set; }

        public string Content { get; set; }

        public DateTime? PostedOn { get; set; }

        public TimeSpan? LifeTime { get; set; }

        public virtual User Author { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}