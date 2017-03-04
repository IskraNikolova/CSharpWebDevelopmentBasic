namespace MvcApp.Web.Views.Home
{
    using System.IO;
    using System.Text;
    using SimpleMVC.Interfaces.Generic;
    using ViewModels;

    public class Signed : IRenderable<SignedViewModel>
    {
        public SignedViewModel Model { get; set; }

        public string Render()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(File.ReadAllText(Constants.ContentPath));
            return builder.ToString();
        }
    }
}