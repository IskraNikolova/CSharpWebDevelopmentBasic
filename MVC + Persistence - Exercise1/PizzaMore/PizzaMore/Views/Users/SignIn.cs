namespace PizzaMore.Views.Users
{
    using System.IO;
    using SimpleMVC.Interfaces;
    public class SignIn : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/signin.html");
        }
    }
}
