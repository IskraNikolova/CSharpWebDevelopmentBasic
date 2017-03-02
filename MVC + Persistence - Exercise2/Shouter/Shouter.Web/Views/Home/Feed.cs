namespace Shouter.Web.Views.Home
{
    using System.IO;
    using SimpleMVC.Interfaces;

    public class Feed : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText(Constants.ContantPath + "feed.html");
        }
    }
}
