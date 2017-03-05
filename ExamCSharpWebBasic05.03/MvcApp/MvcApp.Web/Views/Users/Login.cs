namespace MvcApp.Web.Views.Users
{
    using System.IO;
    using System.Text;
    using SimpleMVC.Interfaces;
    public class Login : IRenderable
    {
        public string Render()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(File.ReadAllText(Constants.ContentPath));
            return builder.ToString();
        }
    }
}
