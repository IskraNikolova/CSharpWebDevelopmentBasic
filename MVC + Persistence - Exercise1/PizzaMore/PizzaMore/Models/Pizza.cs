namespace PizzaMore.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Recipe { get; set; }

        public string ImageUrl { get; set; }

        public int DownVote { get; set; }

        public int UpVote { get; set; }

        public virtual User Owner { get; set; }
    }
}
