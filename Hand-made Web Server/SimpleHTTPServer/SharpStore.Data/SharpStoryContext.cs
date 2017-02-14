namespace SharpStore.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
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
    }
}