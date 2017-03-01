namespace Shouter.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Common.Models;
    using Models;

    public class ShouterContext : DbContext
    {
        public ShouterContext()
            : base("name=ShouterContext")
        {
        }
        public static ShouterContext Create()
        {
            return new ShouterContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Shout> Shoutes { get; set; }

        public IDbSet<Session> Sessions { get; set; }

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