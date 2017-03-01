namespace Shouter.Web.Views.Users
{
    using System.IO;
    using SimpleMVC.Interfaces;
    public class Login : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../Content/login.html");
        }
    }
}
