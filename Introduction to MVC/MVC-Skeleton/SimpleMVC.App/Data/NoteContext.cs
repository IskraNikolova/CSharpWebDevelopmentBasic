namespace SimpleMVC.App.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;

    public class NoteContext : DbContext
    {
        public NoteContext()
            : base("name=NoteContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Note> Notes { get; set; }
    }
}