namespace PizzaMore.Models
{
    using System.Collections.Generic;

    public class User
    {
        private ICollection<Pizza> pizzas;

        public User()
        {
            this.pizzas = new HashSet<Pizza>();
        }

        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Pizza> Pizzas
        {
            get { return this.pizzas; }
            set { this.pizzas = value; }
        }
    }
}