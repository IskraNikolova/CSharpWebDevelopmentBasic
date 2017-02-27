namespace SharpStore.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<SharpStoreContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SharpStoreContext context)
        {
            var knife3 = new Knife()
            {
                Name = "Knife3",
                Price = 2300,
                ImageUrl =
                   "http://vignette1.wikia.nocookie.net/fallout/images/6/6e/Knife_FO3.png/revision/latest?cb=20120731224049"
            };


            context.Knives.AddOrUpdate(knife3);
            context.SaveChanges();
        }
    }
}