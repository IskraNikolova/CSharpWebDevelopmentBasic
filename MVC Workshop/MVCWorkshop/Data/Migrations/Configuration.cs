namespace Data.Migrations
{
    using Data;

    internal sealed class Configuration : DbMigrationsConfiguration<SharpStoreContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SharpStoreContext context)
        {
            context.Knives.AddOrUpdate(knife => new Knife[]
            {
              new Knife()
              {
                  Name = "Knife1",
                  Price = 2300,
                  ImageUrl = "http://vignette1.wikia.nocookie.net/fallout/images/6/6e/Knife_FO3.png/revision/latest?cb=20120731224049"
              },
              new Knife()
              {
                  Name = "Knife2",
                  Price = 300,
                  ImageUrl = "https://static.boker.de/us/images/zoom/02mb207.jpg"
              },
              new Knife()
              {
                  Name = "Knife8",
                  Price = 2300999,
                  ImageUrl = "http://vignette1.wikia.nocookie.net/fallout/images/6/6e/Knife_FO3.png/revision/latest?cb=20120731224049"
              }
            });
        }
    }
}