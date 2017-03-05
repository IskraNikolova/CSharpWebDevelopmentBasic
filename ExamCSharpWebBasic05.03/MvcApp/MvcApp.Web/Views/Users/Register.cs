namespace MvcApp.Web.Views.Users
{
    using System.IO;
    using System.Text;
    using SimpleMVC.Interfaces;

    public class Register : IRenderable
    {
        public string Render()
        {
            StringBuilder builder = new StringBuilder();
            //builder.Append(File.ReadAllText(Constants.ContentPath + "header.html"));
            //builder.Append(File.ReadAllText(Constants.ContentPath + "menu.html"));
            //builder.Append(File.ReadAllText(Constants.ContentPath + "register.html"));
            //builder.Append(File.ReadAllText(Constants.ContentPath + "footer.html"));

            return File.ReadAllText("../../Content/register.html");
        }
    }
}