namespace SharpStore.Data.Data
{
    using System.Data.Entity;
    using Migrations;
    using Models;

    public class SharpStoreContext : DbContext
    {
        public SharpStoreContext()
            : base("name=SharpStoreContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SharpStoreContext, Configuration>());
        }

         public virtual DbSet<Knife> Knives { get; set; }
    }
}