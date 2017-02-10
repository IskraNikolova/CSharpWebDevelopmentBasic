﻿namespace PizzaMore.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Pizza
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Recipe { get; set; }

        public string ImageUrl { get; set; }

        public int UpVotes { get; set; }

        public int DownVotes { get; set; }

        [ForeignKey("Owner")]
        public int OwnerId { get; set; }

        public virtual User Owner { get; set; }
    }
}
