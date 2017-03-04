namespace MvcApp.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Common.Models;
    using Migrations;
    using Models;

    public class MvcAppContext : DbContext
    {
        public MvcAppContext()
            : base("MvcAppContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MvcAppContext, Configuration>());
        }
        public static MvcAppContext Create()
        {
            return Data.Context;
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Login> Sessions { get; set; }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}