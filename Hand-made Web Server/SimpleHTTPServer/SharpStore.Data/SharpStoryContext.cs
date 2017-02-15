namespace SharpStore.Data
{
    using System.Data.Entity;
    using Migrations;
    using Models;

    public class SharpStoryContext : DbContext
    {
        public SharpStoryContext()
            : base("name=SharpStoryContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SharpStoryContext, Configuration>());
        }

        public virtual DbSet<Knife> Knives { get; set; }

        public virtual DbSet<Message> Messages { get; set; }
    }
}