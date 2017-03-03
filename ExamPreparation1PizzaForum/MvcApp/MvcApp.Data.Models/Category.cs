namespace MvcApp.Data.Models
{
    using System;
    using System.Collections.Generic;
    using Common.Models;

    public class Category : AuditInfo, IDeletableEntity
    {
        public Category()
        {
            this.Topics = new HashSet<Topic>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}