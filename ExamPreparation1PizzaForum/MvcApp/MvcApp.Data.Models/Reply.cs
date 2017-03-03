namespace MvcApp.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;

    public class Reply : AuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        [ForeignKey("Topic")]
        public int TopicId { get; set; }

        public string Content { get; set; }

        public DateTime? PublishDate { get; set; }

        public string ImageUrl { get; set; }

        public virtual User Author { get; set; }

        public virtual Topic Topic { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
