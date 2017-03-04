namespace MvcApp.Web.Views.Home
{
    using System.IO;
    using System.Text;
    using SimpleMVC.Interfaces.Generic;
    using ViewModels;
    public class Index : IRenderable<SignedViewModel>
    {
        public SignedViewModel Model { get; set; }

        public string Render()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(File.ReadAllText(Constants.ContentPath + "header.html"));
            if (!string.IsNullOrEmpty(this.Model.Username))
            {
                builder.Append(File.ReadAllText(Constants.ContentPath + "menu.html"));
            }
            else
            {
                builder.Append(string.Format(File.ReadAllText(Constants.ContentPath + "menu-logged.html"),
                                             this.Model.ToString()));
            }
                       
            builder.Append(File.ReadAllText(Constants.ContentPath + "index.html"));
            builder.Append(File.ReadAllText(Constants.ContentPath + "footer.html"));

            return builder.ToString();
        }
    }
}
