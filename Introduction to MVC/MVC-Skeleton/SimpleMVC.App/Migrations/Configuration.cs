namespace SimpleMVC.App.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<Data.NoteContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "SimpleMVC.App.Data.NoteContext";
        }

        protected override void Seed(Data.NoteContext context)
        {
        }
    }
}
