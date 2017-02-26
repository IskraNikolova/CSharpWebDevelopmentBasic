namespace Data.Data
{
    using System.Data.Entity;
    using Migrations;

    public class SharpStoreContext : DbContext
    {
        public SharpStoreContext()
            : base(nameOrConnectionString: "name=SharpStoreContext")
        {
            Database.SetInitializer(strategy: new MigrateDatabaseToLatestVersion<SharpStoreContext, Configuration>());
        }

         public virtual DbSet<Knife> Knives { get; set; }
    }
}