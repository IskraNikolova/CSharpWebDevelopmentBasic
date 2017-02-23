namespace SharpStore.Views.Home
{
    using System.IO;
    using SimpleMVC.Interfaces;

    public class Products : IRenderable

    {
        public string Render()
        {
            return File.ReadAllText("../../content/products.html");
        }
    }
}
