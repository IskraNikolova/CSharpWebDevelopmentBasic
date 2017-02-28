namespace PizzaMore.Views.Home
{
    using System.IO;
    using SimpleMVC.Interfaces;
    public class IndexLogin : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/loginHome.html");
        }
    }
}