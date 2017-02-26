namespace SharpStore.Views.Home
{
    using System.IO;
    using SimpleMVC.Interfaces;

    public class Index : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText(path: "../../content/home.html");
        }
    }
}
