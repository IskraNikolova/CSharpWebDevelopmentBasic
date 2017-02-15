namespace AddKnife
{
    using SharpStore.Data;
    using SharpStore.Data.Models;

    public class AddKnife
    {
        public static void Main()
        {
            var context = new SharpStoryContext();

            context.Knives.Add(new Knife()
            {
                Name = "Sharp404",
                ImageUrl = "https://i.ytimg.com/vi/YK2fXc8S7Xo/maxresdefault.jpg",
                Price = 560.00m
            });

            context.Knives.Add(new Knife()
            {
                Name = "Sharp4",
                ImageUrl = "https://cdn.shopify.com/s/files/1/0955/3610/products/Oakridge_Gardens_Cutting_Shears_On_Tray_1024x1024.jpg?v=1446045972",
            });
            context.Knives.Add(new Knife()
            {
                Name = "Sharp404",
                ImageUrl = "https://i.ytimg.com/vi/YK2fXc8S7Xo/maxresdefault.jpg",
                Price = 560.00m
            });
            context.SaveChanges();
        }
    }
}
