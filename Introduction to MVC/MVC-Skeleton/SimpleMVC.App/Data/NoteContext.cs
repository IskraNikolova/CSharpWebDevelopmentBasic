namespace SimpleMVC.App.Data
{
    using System.Data.Entity;
    using Migrations;
    using Models;
    using Mvc.Interfaces;

    public class NoteContext : DbContext, IDbIdentityContext
    {
        public NoteContext()
            : base("name=NoteContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NoteContext, Configuration>());
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Note> Notes { get; set; }

        public virtual DbSet<Login> Logins { get; set; }

        public void Save()
        {
            this.SaveChanges();
        }
    }
}