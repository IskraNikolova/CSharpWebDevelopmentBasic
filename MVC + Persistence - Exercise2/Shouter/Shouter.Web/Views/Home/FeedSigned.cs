namespace Shouter.Web.Views.Home
{
    using System.IO;
    using SimpleMVC.Interfaces.Generic;
    using ViewModels;
    public class FeedSigned : IRenderable<SignedViewModel>
    {
        public SignedViewModel Model { get; set; }

        public string Render()
        {
            string template = File.ReadAllText(Constants.ContantPath + "feed-signed.html");
            var format = string.Format(template, this.Model);

            return format;
        }
    }
}