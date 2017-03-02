namespace Shouter.Web.Views.Users
{
    using System.IO;
    using SimpleMVC.Interfaces;

    public class Register : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText(Constants.ContantPath + "register.html");
        }
    }
}