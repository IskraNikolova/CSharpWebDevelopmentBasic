namespace PizzaMore.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Migrations;
    using Models;

    public class PizzaStoreContext : DbContext
    {
        public PizzaStoreContext()
            : base("PizzaStoreContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PizzaStoreContext, Configuration>());
        }

        public virtual DbSet<Pizza> Pizzas { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Session> Sessions { get; set; }
    }
}