namespace Shouter.Web.Views.Home
{
    using System.IO;
    using SimpleMVC.Interfaces;
    public class Register : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../Content/register.html");
;        }
    }
}
